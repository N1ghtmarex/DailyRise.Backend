using Application.UserChallenges.Dtos;
using Application.UserChallenges.Mappers;
using Application.UserChallenges.Queries;
using Core.EntityFramework.Features.SearchPagination;
using Core.EntityFramework.Features.SearchPagination.Models;
using Core.Exceptions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TgMiniAppAuth.AuthContext.User;

namespace Application.UserChallenges.Handlers;

internal class UserChallengesQueriesHandlers(ApplicationDbContext dbContext, ITelegramUserAccessor telegramUserAccessor)
    : IRequestHandler<GetUserChallengeListQuery, PagedResult<UserChallengesListViewModel>>,
    IRequestHandler<GetUserChallengeCheckInsQuery, List<UserChallengeCheckInListViewModel>>
{
    public async Task<PagedResult<UserChallengesListViewModel>> Handle(GetUserChallengeListQuery request, CancellationToken cancellationToken)
    {
        var telegramId = telegramUserAccessor.User.Id;

        var user = await dbContext.Users
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.TelegramId == telegramId, cancellationToken)
                ?? throw new ObjectNotFoundException($"Пользователь с Telegram ID = \"{telegramId}\" не найден");

        var query = dbContext.UserChallengeBinds
            .AsNoTracking()
            .Include(x => x.Challenge)
            .Where(x => x.UserId == user.Id)
            .OrderBy(x => x.Challenge!.Name)
            .ApplySearch(request, x => x.Challenge!.Name);

        var result = await query
            .ApplyPagination(request)
            .ProjectToListViewModel()
            .ToListAsync(cancellationToken);

        return result.AsPagedResult(request, await query.CountAsync(cancellationToken));
    }

    public async Task<List<UserChallengeCheckInListViewModel>> Handle(GetUserChallengeCheckInsQuery request, CancellationToken cancellationToken)
    {
        var challenge = await dbContext.Challenges
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == request.ChallengeId, cancellationToken)
                ?? throw new ObjectNotFoundException($"Испытание с ID = \"{request.ChallengeId}\" не найдено");

        var checkIns = await dbContext.UserChallengeCheckIns
            .AsNoTracking()
            .Include(x => x.UserChallengeBind)
            .Where(x => x.UserChallengeBind!.ChallengeId == challenge.Id)
            .ProjectToListViewModel()
            .ToListAsync(cancellationToken);

        return checkIns;
    }
}
