using Application.Challenges.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Challenges.Queries;

public class GetChallengeQuery : IRequest<ChallengeViewModel>
{
    [FromRoute]
    public required Ulid ChallengeId { get; set; }
}
