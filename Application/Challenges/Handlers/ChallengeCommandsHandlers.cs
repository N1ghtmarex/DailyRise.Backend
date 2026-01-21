using Application.Challenges.Commands;
using Application.Challenges.Mappers;
using Core.Exceptions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TgMiniAppAuth.AuthContext.User;

namespace Application.Challenges.Handlers;

internal class ChallengeCommandsHandlers(ApplicationDbContext dbContext, ITelegramUserAccessor telegramUserAccessor) 
    : IRequestHandler<CreateChallengeCommand, Ulid>
{
    public async Task<Ulid> Handle(CreateChallengeCommand request, CancellationToken cancellationToken)
    {
        var telegramId = telegramUserAccessor.User.Id;

        var user = await dbContext.Users
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.TelegramId == telegramId, cancellationToken)
                ?? throw new ObjectNotFoundException($"Пользователь с Telegram ID = \"{telegramId}\" не найден");

        var challengeToCreate = ChallengeMapper.MapToEntity(request.Body, user.Id);

        if (challengeToCreate.StartDate.Date < DateTime.UtcNow.Date)
        {
            throw new BusinessLogicException($"Время начала испытание не может быть раньше текущего времени");
        }

        if (challengeToCreate.EndDate <= challengeToCreate.StartDate)
        {
            throw new BusinessLogicException($"Время окончания испытания должно быть позже начала");
        }

        var createdChallenge = await dbContext.AddAsync(challengeToCreate, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return createdChallenge.Entity.Id;
    }
}
