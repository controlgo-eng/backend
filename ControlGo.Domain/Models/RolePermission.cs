using System;
using System.Collections.Generic;
using System.Text;

namespace ControlGo.Domain.Models
{
    public class RolePermission
    {
        public long Id { get; set; }
        public long TenantId { get; set; }
        public long RoleId { get; set; }
        public long PermissionId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Tenant Tenant { get; set; }
        public Role Role { get; set; }
        public Permission Permission { get; set; }
    }
}
