using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityConfigurations;

public class UserChallengeBindConfiguration : IEntityTypeConfiguration<UserChallengeBind>
{
    public void Configure(EntityTypeBuilder<UserChallengeBind> builder)
    {
        builder.ToTable("user_challenge_bind");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .IsRequired()
            .HasConversion(
                x => x.ToString(),
                x => Ulid.Parse(x)
            );
        builder.HasIndex(x => x.Id).IsUnique();

        builder.Property(x => x.ChallengeId).IsRequired();
        builder.HasIndex(x => x.ChallengeId).IsUnique(false);
        builder.HasOne(x => x.Challenge)
            .WithMany(x => x.UserChallenges)
            .HasForeignKey(x => x.ChallengeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.UserId).IsRequired();
        builder.HasIndex(x => x.UserId).IsUnique(false);
        builder.HasOne(x => x.User)
            .WithMany(x => x.UserChallenges)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.Status).IsRequired();
        builder.HasIndex(x => x.Status).IsUnique(false);

        builder.Property(x => x.JoinedAt).IsRequired();
    }
}
