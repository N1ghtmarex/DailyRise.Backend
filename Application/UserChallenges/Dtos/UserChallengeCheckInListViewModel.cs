using Application.Challenges.Dtos;
using Domain.Enums;

namespace Application.UserChallenges.Dtos;

public class UserChallengeCheckInListViewModel
{
    public required Ulid Id { get; set; }
    public UserChallengesListViewModel? UserChallengeBind { get; set; }
    public required DateTimeOffset CheckInDate { get; set; }
    public required CheckInStatus Status { get; set; }
}
