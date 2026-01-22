using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.UserChallenges.Commands;

public class AcceptChallengeCommand : IRequest<Ulid>
{
    [FromRoute]
    public required Ulid ChallengeId { get; set; }
}
