using ControlGo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControlGo.Infrastructure.ConfigurationEntities
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        private const string TABLE_NAME = "Role";
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable(TABLE_NAME);

            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).ValueGeneratedOnAdd();

            builder.Property(r => r.TenantId)
                .IsRequired(false);

            builder.Property(r => r.Name)
                .IsRequired(false)
                .HasMaxLength(255);

            builder.Property(r => r.Description)
                .IsRequired(false)
                .HasMaxLength(255);

            builder.Property(r => r.Hierarchy)
                .IsRequired(false);

            builder.Property(r => r.CreatedAt)
                .IsRequired(false);

            builder.Property(r => r.UpdatedAt)
                .IsRequired(false);

            builder.HasOne(r => r.Tenant)
                .WithMany()
                .HasForeignKey(r => r.TenantId);

            builder.HasMany(r => r.RolePermissions)
                .WithOne(rp => rp.Role)
                .HasForeignKey(rp => rp.RoleId);

            builder.HasMany(r => r.UserRole)
                .WithOne(ur => ur.Role)
                .HasForeignKey(ur => ur.RoleId);
        }
    }
}
