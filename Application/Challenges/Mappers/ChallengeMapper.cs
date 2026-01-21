using Application.Challenges.Dtos;
using Application.Mappers;
using Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Application.Challenges.Mappers;

[Mapper]
[UseStaticMapper(typeof(GeneralMapper))]
public static partial class ChallengeMapper
{
    [MapValue(nameof(User.Id), Use = nameof(@GeneralMapper.GenerateId))]
    public static partial Challenge MapToEntity(CreateChallengeModel source, Ulid authorId);
}
