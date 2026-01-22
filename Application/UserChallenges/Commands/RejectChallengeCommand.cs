using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.UserChallenges.Commands;

public class RejectChallengeCommand : IRequest<Ulid>
{
    [FromRoute]
    public required Ulid ChallengeId { get; set; }
}
