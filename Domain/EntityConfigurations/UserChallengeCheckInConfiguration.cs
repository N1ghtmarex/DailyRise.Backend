using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityConfigurations;

public class UserChallengeCheckInConfiguration : IEntityTypeConfiguration<UserChallengeCheckIn>
{
    public void Configure(EntityTypeBuilder<UserChallengeCheckIn> builder)
    {
        builder.ToTable("user_challenge_check_in");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .IsRequired()
            .HasConversion(
                x => x.ToString(),
                x => Ulid.Parse(x)
            );
        builder.HasIndex(x => x.Id).IsUnique();

        builder.Property(x => x.UserChallengeBindId)
            .HasConversion(
                x => x.ToString(),
                x => Ulid.Parse(x)
            ).IsRequired();
        builder.HasIndex(x => x.UserChallengeBindId).IsUnique(false);
        builder.HasOne(x => x.UserChallengeBind)
            .WithMany(x => x.CheckIns)
            .HasForeignKey(x => x.UserChallengeBindId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.Status).IsRequired();
        builder.HasIndex(x => x.Status).IsUnique(false);
    }
}
