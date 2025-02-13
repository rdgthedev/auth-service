using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth_Service.Infrastructure.Data.Mappings;

public class RefreshTokenMapping : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable("RefreshTokens");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id)
            .HasColumnName(nameof(RefreshToken.Id))
            .HasColumnType("UNIQUEIDENTIFIER")
            .HasMaxLength(128)
            .IsRequired();

        builder.Property(r => r.Token)
            .HasColumnName(nameof(RefreshToken.Token))
            .HasColumnType("NVARCHAR")
            .HasMaxLength(128)
            .IsRequired();

        builder.Property(r => r.ExpirationDate)
            .HasColumnName(nameof(RefreshToken.ExpirationDate))
            .HasColumnType("DATETIME")
            .IsRequired();

        builder.Property(r => r.CreatedAt)
            .HasColumnName(nameof(RefreshToken.CreatedAt))
            .HasColumnType("DATETIME2")
            .IsRequired();

        builder.Property(r => r.UpdatedAt)
            .HasColumnName(nameof(RefreshToken.UpdatedAt))
            .HasColumnType("DATETIME2")
            .IsRequired();

        builder.Property(r => r.DeletedAt)
            .HasColumnName(nameof(RefreshToken.DeletedAt))
            .HasColumnType("DATETIME2")
            .IsRequired();

        builder.Property(r => r.IsValid)
            .HasColumnName(nameof(RefreshToken.IsValid))
            .HasColumnType("BOOLEAN")
            .IsRequired();

        builder.HasOne(r => r.User)
            .WithMany()
            .HasForeignKey(r => r.UserId)
            .HasConstraintName(nameof(RefreshToken.UserId))
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.Ignore(r => r.UpdatedAt);
        builder.Ignore(r => r.DeletedAt);

        builder.HasIndex(r => r.Id, "IX_RefreshTokens_Id").IsUnique();
        builder.HasIndex(r => r.Token, "IX_RefreshTokens_Token").IsUnique();
    }
}