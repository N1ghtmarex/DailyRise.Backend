using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityConfigurations;

public class ChallengeQuestBindConfiguration : IEntityTypeConfiguration<ChallengeQuestBind>
{
    public void Configure(EntityTypeBuilder<ChallengeQuestBind> builder)
    {
        builder.ToTable("challenge_quest_bind");

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
            .WithMany(x => x.ChallengeQuests)
            .HasForeignKey(x => x.ChallengeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.QuestId).IsRequired();
        builder.HasIndex(x => x.QuestId).IsUnique(false);
        builder.HasOne(x => x.Quest)
            .WithMany(x => x.ChallngeQuests)
            .HasForeignKey(x => x.QuestId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
