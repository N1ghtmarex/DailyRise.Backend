using Application.Users.Commands;
using Application.Users.Mappers;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Handlers;

internal class UserCommandsHandlers(ApplicationDbContext dbContext) : IRequestHandler<CreateUserCommand, Ulid>
{
    public async Task<Ulid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var userWithSameTelegramId = await dbContext.Users.SingleOrDefaultAsync(x => x.TelegramId == request.Body.TelegramId, cancellationToken);

        if (userWithSameTelegramId  != null)
        {
            throw new Exception($"Пользователь с Telegram ID = \"{userWithSameTelegramId.TelegramId}\" уже существует");
        }    

        var userToCreate = UserMapper.MapToEntity(request.Body);

        var createdUser = await dbContext.AddAsync(userToCreate, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return createdUser.Entity.Id;
    }
}
