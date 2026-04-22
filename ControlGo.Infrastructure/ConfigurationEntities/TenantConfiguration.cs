using ControlGo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControlGo.Infrastructure.ConfigurationEntities
{
    public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
    {
        private const string TABLE_NAME = "Tenant";
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.ToTable(TABLE_NAME);

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.HasIndex(t => t.ExternalId)
            .IsUnique()
            .HasFilter(null)
            .HasDatabaseName("UQ_tenants_externalId");

            builder.HasIndex(t => t.Slug)
                .IsUnique()
                .HasDatabaseName("UQ_tenants_slug");            

            builder.Property(p => p.CreatedAt)
                .IsRequired(false);

            builder.Property(p => p.UpdatedAt)
                .IsRequired(false);

            builder.Property(p => p.DeletedAt)
              .IsRequired(false);

            builder.HasMany(t => t.TenantSettings)
                .WithOne(ts => ts.Tenant)
                .HasForeignKey(ts => ts.TenantId);

            builder.HasMany(t => t.TenantUsers)
                .WithOne(tu => tu.Tenant)
                .HasForeignKey(tu => tu.TenantId);
        }
    }
}
