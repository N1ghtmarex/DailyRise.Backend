using Application.UserChallenges.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.UserChallenges.Commands;

public class AddCheckInCommand : IRequest<Ulid>
{
    [FromBody]
    public required AddCheckInModel Body { get; set; }
}
