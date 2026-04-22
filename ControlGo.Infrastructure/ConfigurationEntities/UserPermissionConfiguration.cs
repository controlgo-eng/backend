using ControlGo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControlGo.Infrastructure.ConfigurationEntities
{
    public class UserPermissionConfiguration : IEntityTypeConfiguration<UserPermission>
    {
        private const string TABLE_NAME = "UserPermission";

        public void Configure(EntityTypeBuilder<UserPermission> builder)
        {
            builder.ToTable(TABLE_NAME);

            builder.HasKey(up => up.Id);
            builder.Property(up => up.Id).ValueGeneratedOnAdd();

            builder.Property(up => up.TenantId).IsRequired();
            builder.Property(up => up.UserId).IsRequired();
            builder.Property(up => up.PermissionId).IsRequired();

            builder.Property(up => up.Type)
                .HasColumnName("type")
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(up => up.CreatedAt);
            builder.Property(up => up.UpdatedAt);

            builder.HasOne(up => up.Tenant)
                .WithMany()
                .HasForeignKey(up => up.TenantId);

            builder.HasOne(up => up.User)
                .WithMany(u => u.UserPermissions)
                .HasForeignKey(up => up.UserId);

            builder.HasOne(up => up.Permission)
                .WithMany()
                .HasForeignKey(up => up.PermissionId);
        }
    }
}
