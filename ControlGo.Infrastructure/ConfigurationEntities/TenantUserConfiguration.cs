using ControlGo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControlGo.Infrastructure.ConfigurationEntities
{
    public class TenantUserConfiguration : IEntityTypeConfiguration<TenantUser>
    {
        private const string TABLE_NAME = "TenantUser";

        public void Configure(EntityTypeBuilder<TenantUser> builder)
        {
            builder.ToTable(TABLE_NAME);

            builder.HasKey(tu => tu.Id);
            builder.Property(tu => tu.Id).ValueGeneratedOnAdd();

            builder.Property(tu => tu.TenantId).IsRequired();
            builder.Property(tu => tu.UserId).IsRequired();
            builder.Property(tu => tu.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder.HasIndex(tu => new { tu.TenantId, tu.UserId })
                .IsUnique()
                .HasDatabaseName("UQ_tenant_user");

            builder.Property(tu => tu.CreatedAt);
            builder.Property(tu => tu.UpdatedAt);

            builder.HasOne(tu => tu.Tenant)
                .WithMany(t => t.TenantUsers)
                .HasForeignKey(tu => tu.TenantId);

            builder.HasOne(tu => tu.User)
                .WithMany()
                .HasForeignKey(tu => tu.UserId);
        }
    }
}
