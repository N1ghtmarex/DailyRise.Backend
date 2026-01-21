using Application.BaseModels;
using Application.Challenges.Dtos;
using Core.EntityFramework.Features.SearchPagination.Models;
using MediatR;

namespace Application.Challenges.Queries;

public class GetChallengeListQuery : SearchablePagedQuery, IRequest<PagedResult<ChallengeListViewModel>>
{
}
