using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth_Service.Infrastructure.Data.Mappings;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .HasColumnName(nameof(User.Id))
            .HasColumnType("UNIQUEIDENTIFIER")
            .HasMaxLength(128)
            .IsRequired();

        builder.Property(u => u.Email)
            .HasColumnName(nameof(User.Email))
            .HasColumnType("VARCHAR")
            .HasMaxLength(128)
            .IsRequired();

        builder.Property(u => u.PasswordHash)
            .HasColumnName(nameof(User.PasswordHash))
            .HasColumnType("VARCHAR")
            .IsRequired();

        builder.HasIndex(u => u.Id, "IX_Users_Id").IsUnique();
        builder.HasIndex(u => u.Email, "IX_Users_Email").IsUnique();
    }
}