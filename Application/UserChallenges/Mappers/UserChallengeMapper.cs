using Application.Mappers;
using Application.UserChallenges.Dtos;
using Domain.Entities;
using Domain.Enums;
using Riok.Mapperly.Abstractions;

namespace Application.UserChallenges.Mappers;

[Mapper]
[UseStaticMapper(typeof(GeneralMapper))]
public static partial class UserChallengeMapper
{
    [MapValue(nameof(User.Id), Use = nameof(@GeneralMapper.GenerateId))]
    public static partial UserChallengeBind MapToEntity(InviteUserToChallengeModel source, InviteStatus status, DateTimeOffset? joinedAt);

    public static partial IQueryable<UserChallengesListViewModel> ProjectToListViewModel(this IQueryable<UserChallengeBind> q);
}
