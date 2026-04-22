using System;
using System.Collections.Generic;
using System.Text;

namespace ControlGo.Domain.Models
{
    public class Role
    {
        public long Id { get; set; }
        public long TenantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte Hierarchy { get; set; } = 99;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Tenant Tenant { get; set; }

        public virtual ICollection<RolePermission> RolePermissions { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
