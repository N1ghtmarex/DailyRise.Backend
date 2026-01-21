using Application.Challenges.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Challenges.Commands;

public class CreateChallengeCommand : IRequest<Ulid>
{
    [FromBody]
    public required CreateChallengeModel Body { get; set; }
}
