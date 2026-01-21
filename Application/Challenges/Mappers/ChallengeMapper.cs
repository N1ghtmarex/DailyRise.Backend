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

    public static partial IQueryable<ChallengeViewModel> ProjectToViewModel(this IQueryable<Challenge> q);
    public static partial IQueryable<ChallengeListViewModel> ProjectToListViewModel(this IQueryable<Challenge> q);
}
