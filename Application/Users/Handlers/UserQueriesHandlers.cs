using Application.Users.Dtos;
using Application.Users.Mappers;
using Application.Users.Queries;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Handlers;

internal class UserQueriesHandlers(ApplicationDbContext dbContext) : IRequestHandler<GetUserQuery, UserViewModel>
{
    public async Task<UserViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Username.ToLower() == request.Username.ToLower(), cancellationToken);
        
        if (user == null)
        {
            throw new Exception($"Пользователь \"{request.Username}\" не найден");
        }

        return UserMapper.MapToViewModel(user);
    }
}
