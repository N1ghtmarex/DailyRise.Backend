using Application.BaseModels;
using Application.UserChallenges.Dtos;
using Core.EntityFramework.Features.SearchPagination.Models;
using MediatR;

namespace Application.UserChallenges.Queries;

public class GetUserChallengeListQuery : SearchablePagedQuery, IRequest<PagedResult<UserChallengesListViewModel>>
{
}
