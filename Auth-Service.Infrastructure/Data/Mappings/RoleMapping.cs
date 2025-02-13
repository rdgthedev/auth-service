using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth_Service.Infrastructure.Data.Mappings;

public class RoleMapping : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id)
            .HasColumnName(nameof(Role.Id))
            .HasColumnType("UNIQUEIDENTIFIER")
            .HasMaxLength(128)
            .IsRequired();

        builder.Property(r => r.Name)
            .HasColumnName(nameof(Role.Name))
            .HasColumnType("NVARCHAR")
            .HasMaxLength(128)
            .IsRequired();

        builder.Property(r => r.CreatedAt)
            .HasColumnName(nameof(Role.CreatedAt))
            .HasColumnType("DATETIME2")
            .IsRequired();

        builder.Property(r => r.UpdatedAt)
            .HasColumnName(nameof(Role.UpdatedAt))
            .HasColumnType("DATETIME2")
            .IsRequired();
    }
}