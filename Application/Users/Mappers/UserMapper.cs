using Application.Mappers;
using Application.Users.Dtos;
using Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Application.Users.Mappers;

[Mapper]
[UseStaticMapper(typeof(GeneralMapper))]
public static partial class UserMapper
{
    [MapValue(nameof(User.Id), Use = nameof(@GeneralMapper.GenerateId))]
    public static partial User MapToEntity(CreateUserModel source);
    public static partial UserViewModel MapToViewModel(User source);
}
