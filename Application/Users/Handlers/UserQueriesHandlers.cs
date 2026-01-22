using Application.Users.Dtos;
using Application.Users.Mappers;
using Application.Users.Queries;
using Core.EntityFramework.Features.SearchPagination;
using Core.EntityFramework.Features.SearchPagination.Models;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Handlers;

internal class UserQueriesHandlers(ApplicationDbContext dbContext) : IRequestHandler<GetUserQuery, UserViewModel>,
    IRequestHandler<GetUserListQuery, PagedResult<UserListViewModel>>
{
    public async Task<UserViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.TelegramId == request.TelegramId, cancellationToken);
        
        if (user == null)
        {
            throw new Exception($"Пользователь с Telegram ID = \"{request.TelegramId}\" не найден");
        }

        return UserMapper.MapToViewModel(user);
    }

    public async Task<PagedResult<UserListViewModel>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
        var query = dbContext.Users
            .AsNoTracking()
            .OrderBy(x => x.Username)
            .ApplySearch(request, x => x.Username);
            
        var result = await query
            .ApplyPagination(request)
            .ProjectToListViewModel()
            .ToListAsync(cancellationToken);

        return result.AsPagedResult(request, await query.CountAsync(cancellationToken));
    }
}
