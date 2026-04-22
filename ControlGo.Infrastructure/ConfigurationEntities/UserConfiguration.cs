using ControlGo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControlGo.Infrastructure.ConfigurationEntities
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        private const string TABLE_NAME = "User";
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(TABLE_NAME);

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Tenant)
                .IsRequired(false);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(p => p.EmailVerifiedAt)
                .IsRequired(false);

            builder.Property(p => p.Password)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(p => p.Status)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.RememberToken)
                .IsRequired(false)
                .HasMaxLength(100);

            builder.Property(p => p.CreatedAt)
                .IsRequired(false);

            builder.Property(p => p.UpdatedAt)
                .IsRequired(false);

            // Relaciones
            builder.HasOne(u => u.Tenant)
                .WithMany()
                .HasForeignKey(u => u.TenantId);

            builder.HasMany(u => u.UserRoles)
                .WithOne(ur => ur.User)
                .HasForeignKey(ur => ur.UserId);

            builder.HasMany(u => u.UserPermissions)
                .WithOne(up => up.User)
                .HasForeignKey(up => up.UserId);
        }
    }
}
