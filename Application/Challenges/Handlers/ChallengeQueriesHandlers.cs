using Application.Challenges.Dtos;
using Application.Challenges.Mappers;
using Application.Challenges.Queries;
using Core.EntityFramework.Features.SearchPagination;
using Core.EntityFramework.Features.SearchPagination.Models;
using Core.Exceptions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Challenges.Handlers;

internal class ChallengeQueriesHandlers(ApplicationDbContext dbContext) : IRequestHandler<GetChallengeQuery, ChallengeViewModel>,
    IRequestHandler<GetChallengeListQuery, PagedResult<ChallengeListViewModel>>
{
    public async Task<ChallengeViewModel> Handle(GetChallengeQuery request, CancellationToken cancellationToken)
    {
        var challenge = await dbContext.Challenges
            .AsNoTracking()
            .ProjectToViewModel()
            .SingleOrDefaultAsync(x => x.Id == request.ChallengeId)
                ?? throw new ObjectNotFoundException($"Испытание \"{request.ChallengeId}\" не найдено");

        return challenge;
    }

    public async Task<PagedResult<ChallengeListViewModel>> Handle(GetChallengeListQuery request, CancellationToken cancellationToken)
    {
        var query = dbContext.Challenges
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .ApplySearch(request, x => x.Name);

        var result = await query
            .ApplyPagination(request)
            .ProjectToListViewModel()
            .ToListAsync(cancellationToken);

        return result.AsPagedResult(request, await query.CountAsync(cancellationToken));

    }
}
