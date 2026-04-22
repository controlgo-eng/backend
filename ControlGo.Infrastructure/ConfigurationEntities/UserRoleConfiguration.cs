using ControlGo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControlGo.Infrastructure.ConfigurationEntities
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        private const string TABLE_NAME = "UserRole";

        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable(TABLE_NAME);

            builder.HasKey(ur => ur.Id);
            builder.Property(ur => ur.Id).ValueGeneratedOnAdd();

            builder.Property(ur => ur.TenantId).IsRequired();
            builder.Property(ur => ur.UserId).IsRequired();
            builder.Property(ur => ur.RoleId).IsRequired();

            builder.Property(ur => ur.CreatedAt);
            builder.Property(ur => ur.UpdatedAt);

            builder.HasOne(ur => ur.Tenant)
                .WithMany()
                .HasForeignKey(ur => ur.TenantId);

            builder.HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            builder.HasOne(ur => ur.Role)
                .WithMany()
                .HasForeignKey(ur => ur.RoleId);
        }
    }
}
