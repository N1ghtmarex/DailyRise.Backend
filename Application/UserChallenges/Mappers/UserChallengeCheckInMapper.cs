using Application.UserChallenges.Dtos;
using Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Application.UserChallenges.Mappers;

[Mapper]
public static partial class UserChallengeCheckInMapper
{
    public static partial IQueryable<UserChallengeCheckInListViewModel> ProjectToListViewModel(this IQueryable<UserChallengeCheckIn> q);
}
