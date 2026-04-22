using ControlGo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControlGo.Infrastructure.ConfigurationEntities
{
    public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
    {
        private const string TABLE_NAME = "RolePermission";

        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.ToTable(TABLE_NAME);

            builder.HasKey(rp => rp.Id);
            builder.Property(rp => rp.Id).ValueGeneratedOnAdd();

            builder.Property(rp => rp.TenantId).IsRequired();
            builder.Property(rp => rp.RoleId).IsRequired();
            builder.Property(rp => rp.PermissionId).IsRequired();

            builder.HasIndex(rp => new { rp.TenantId, rp.RoleId, rp.PermissionId })
                .IsUnique()
                .HasDatabaseName("UQ_role_permissions");

            builder.Property(rp => rp.CreatedAt);
            builder.Property(rp => rp.UpdatedAt);

            builder.HasOne(rp => rp.Tenant)
                .WithMany()
                .HasForeignKey(rp => rp.TenantId);

            builder.HasOne(rp => rp.Role)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(rp => rp.RoleId);

            builder.HasOne(rp => rp.Permission)
                .WithMany()
                .HasForeignKey(rp => rp.PermissionId);
        }
    }
}
