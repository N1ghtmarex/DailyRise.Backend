using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("user");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .IsRequired()
            .HasConversion(
                x => x.ToString(),
                x => Ulid.Parse(x)
            );
        builder.HasIndex(x => x.Id).IsUnique();

        builder.Property(x => x.TelegramId).IsRequired();
        builder.HasIndex(x => x.TelegramId).IsUnique();

        builder.Property(x => x.Username).IsRequired(false).HasMaxLength(30);
        builder.HasIndex(x => x.Username).IsUnique();

        builder.Property(x => x.Firstname).IsRequired().HasMaxLength(30);
        builder.HasIndex(x => x.Firstname).IsUnique(false);

        builder.Property(x => x.Lastname).IsRequired(false).HasMaxLength(30);
        builder.HasIndex(x => x.Lastname).IsUnique(false);

        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt).IsRequired(false);
        builder.Property(x => x.IsArchive).IsRequired();
    }
}
