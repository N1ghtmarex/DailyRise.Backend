using Application.UserChallenges.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.UserChallenges.Queries;

public class GetUserChallengeCheckInsQuery : IRequest<List<UserChallengeCheckInListViewModel>>
{
    [FromQuery]
    public required Ulid ChallengeId { get; set; }
}
