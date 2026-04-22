using System;
using System.Collections.Generic;
using System.Text;

namespace ControlGo.Domain.Models
{
    public class UserPermission
    {
        public long Id { get; set; }
        public long TenantId { get; set; }
        public long UserId { get; set; }
        public long PermissionId { get; set; }
        public string Type { get; set; } // allow | deny
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Tenant Tenant { get; set; }
        public User User { get; set; }
        public Permission Permission { get; set; }
    }
}
