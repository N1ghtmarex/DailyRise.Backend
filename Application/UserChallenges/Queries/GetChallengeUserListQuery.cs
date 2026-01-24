using Application.BaseModels;
using Application.Users.Dtos;
using Core.EntityFramework.Features.SearchPagination.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.UserChallenges.Queries;

public class GetChallengeUserListQuery : SearchablePagedQuery, IRequest<PagedResult<UserListViewModel>>
{
    [FromRoute]
    public required Ulid ChallengeId { get; set; }
}
