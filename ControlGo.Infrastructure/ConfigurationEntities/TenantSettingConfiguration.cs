using ControlGo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControlGo.Infrastructure.ConfigurationEntities
{
    public class TenantSettingConfiguration : IEntityTypeConfiguration<TenantSetting>
    {
        private const string TABLE_NAME = "TenantSetting";

        public void Configure(EntityTypeBuilder<TenantSetting> builder)
        {
            builder.ToTable(TABLE_NAME);

            builder.HasKey(ts => ts.Id);
            builder.Property(ts => ts.Id).ValueGeneratedOnAdd();

            builder.Property(ts => ts.TenantId).IsRequired();
            builder.Property(ts => ts.Key)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(ts => ts.Value); // nvarchar(max)

            builder.HasIndex(ts => new { ts.TenantId, ts.Key })
                .IsUnique()
                .HasDatabaseName("UQ_tenant_settings");

            builder.Property(ts => ts.CreatedAt);
            builder.Property(ts => ts.UpdatedAt);

            builder.HasOne(ts => ts.Tenant)
                .WithMany(t => t.TenantSettings)
                .HasForeignKey(ts => ts.TenantId)
                .HasConstraintName("FK_tenant_settings_tenant");
        }
    }
}
