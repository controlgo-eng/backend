using ControlGo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControlGo.Infrastructure.ConfigurationEntities
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        private const string TABLE_NAME = "Permissions";
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable(TABLE_NAME);

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Code)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(p => p.Description)
                .IsRequired(false)
                .HasMaxLength(255);

            builder.Property(p => p.CreatedAt)
                .IsRequired(false);

            builder.Property(p => p.UpdatedAt)
                .IsRequired(false);

            builder.HasMany(p => p.RolePermission)
                .WithOne(rp => rp.Permission)
                .HasForeignKey(rp => rp.PermissionId);

            builder.HasMany(p => p.UserPermission)
                .WithOne(up => up.Permission)
                .HasForeignKey(up => up.PermissionId);
        }
    }
}
