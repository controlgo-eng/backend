using System;
using System.Collections.Generic;
using System.Text;

namespace ControlGo.Domain.Models
{
    public class Tenant
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string ExternalId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }

        public virtual ICollection<TenantSetting> TenantSettings { get; set; }
        public virtual ICollection<TenantUser> TenantUsers { get; set; }
    }
}
