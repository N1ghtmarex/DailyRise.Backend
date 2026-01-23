using Application.UserChallenges.Commands;
using Application.UserChallenges.Dtos;
using Application.UserChallenges.Mappers;
using Core.Exceptions;
using Domain;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TgMiniAppAuth.AuthContext.User;

namespace Application.UserChallenges.Handlers;

internal class UserChallengesCommandsHandlers(ApplicationDbContext dbContext, ITelegramUserAccessor telegramUserAccessor) 
    : IRequestHandler<InviteUserToChallengeCommand, Ulid>, IRequestHandler<AcceptChallengeCommand, Ulid>,
    IRequestHandler<RejectChallengeCommand, Ulid>
{
    public async Task<Ulid> Handle(InviteUserToChallengeCommand request, CancellationToken cancellationToken)
    {
        var invitedUser = await dbContext.Users
            .AsNoTracking()
            .Include(x => x.ParticipatingChallenges)
            .SingleOrDefaultAsync(x => x.Id == request.Body.UserId && !x.IsArchive, cancellationToken)
                ?? throw new ObjectNotFoundException($"Пользователь с идентификатором \"{request.Body.UserId}\" не найден или удален");

        var challenge = await dbContext.Challenges
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == request.Body.ChallengeId && !x.IsArchive, cancellationToken)
                ?? throw new ObjectNotFoundException($"Испытание с идентификатором \"{request.Body.ChallengeId}\" не найдено или уже завершено");

        var telegramId = telegramUserAccessor.User.Id;

        var hostUser = await dbContext.Users
            .AsNoTracking()
            .Include(x => x.ParticipatingChallenges)
            .Include(x => x.CreatedChallenges)
            .SingleOrDefaultAsync(x => x.TelegramId == telegramId, cancellationToken)
                ?? throw new ObjectNotFoundException($"Пользователь с идентификатором \"{telegramId}\" не найден или удален");

        if ((hostUser.CreatedChallenges != null && hostUser.CreatedChallenges.Count > 0 
                && hostUser.CreatedChallenges.Select(x => x.Id).Contains(challenge.Id))
            || (hostUser.ParticipatingChallenges != null && hostUser.ParticipatingChallenges.Count > 0 
                    &&hostUser.ParticipatingChallenges.Select(x => x.Id).Contains(challenge.Id)))
        {
            throw new BusinessLogicException($"Вы не можете приглашать участников в это испытание");
        }

        if (invitedUser.ParticipatingChallenges != null && invitedUser.ParticipatingChallenges.Count > 0
                && invitedUser.ParticipatingChallenges.Select(x => x.ChallengeId).Contains(challenge.Id))
        {
            throw new BusinessLogicException($"Этот пользователь уже приглашен");
        }

        var userChallengeBindToCreate = UserChallengeMapper.MapToEntity(request.Body, InviteStatus.Pending, null);

        var createdUserChallengeBind = await dbContext.AddAsync(userChallengeBindToCreate, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return createdUserChallengeBind.Entity.Id;
    }

    public async Task<Ulid> Handle(AcceptChallengeCommand request, CancellationToken cancellationToken)
    {
        var telegramId = telegramUserAccessor.User.Id;
        var user = await dbContext.Users
            .AsNoTracking()
            .Include(x => x.ParticipatingChallenges)
            .Include(x => x.CreatedChallenges)
            .SingleOrDefaultAsync(x => x.TelegramId == telegramId, cancellationToken)
                ?? throw new ObjectNotFoundException($"Пользователь с идентификатором \"{telegramId}\" не найден или удален");

        var challenge = await dbContext.Challenges
            .AsNoTracking()
            .SingleOrDefaultAsync(x => !x.IsArchive && x.Id == request.ChallengeId, cancellationToken)
                ?? throw new ObjectNotFoundException($"Испытание с идентификатором \"{request.ChallengeId}\" не найдено или завершено");

        var userChallenge = await dbContext.UserChallengeBinds
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.UserId == user.Id && x.ChallengeId == challenge.Id, cancellationToken)
                ?? UserChallengeMapper.MapToEntity(new InviteUserToChallengeModel { ChallengeId = challenge.Id, UserId = user.Id }, InviteStatus.Accepted, DateTimeOffset.Now);

        userChallenge.Status = InviteStatus.Accepted;
        await dbContext.SaveChangesAsync(cancellationToken);

        return userChallenge.Id;
    }

    public async Task<Ulid> Handle(RejectChallengeCommand request, CancellationToken cancellationToken)
    {
        var telegramId = telegramUserAccessor.User.Id;
        var user = await dbContext.Users
            .AsNoTracking()
            .Include(x => x.ParticipatingChallenges)
            .Include(x => x.CreatedChallenges)
            .SingleOrDefaultAsync(x => x.TelegramId == telegramId, cancellationToken)
                ?? throw new ObjectNotFoundException($"Пользователь с идентификатором \"{telegramId}\" не найден или удален");

        var challenge = await dbContext.Challenges
            .AsNoTracking()
            .SingleOrDefaultAsync(x => !x.IsArchive && x.Id == request.ChallengeId, cancellationToken)
                ?? throw new ObjectNotFoundException($"Испытание с идентификатором \"{request.ChallengeId}\" не найдено или завершено");

        var userChallenge = await dbContext.UserChallengeBinds
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.UserId == user.Id && x.ChallengeId == challenge.Id, cancellationToken)
                ?? throw new BusinessLogicException($"Вы не являетесь участником этого испытания");

        if (userChallenge.Status != InviteStatus.Pending)
        {
            throw new BusinessLogicException($"Приглашение не находится на рассмотрении");
        }

        userChallenge.Status = InviteStatus.Rejected;
        await dbContext.SaveChangesAsync(cancellationToken);

        return userChallenge.Id;
    }
}
