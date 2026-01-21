using Application.Users.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Users.Queries;

public class GetUserQuery : IRequest<UserViewModel>
{
    /// <summary>
    /// Имя пользователя
    /// </summary>
    [FromRoute]
    public required string Username { get; set; }
}
