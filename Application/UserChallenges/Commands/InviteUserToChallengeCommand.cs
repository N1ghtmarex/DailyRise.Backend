using Application.UserChallenges.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.UserChallenges.Commands;

public class InviteUserToChallengeCommand : IRequest<Ulid>
{
    [FromBody]
    public required InviteUserToChallengeModel Body { get; set; }
}
