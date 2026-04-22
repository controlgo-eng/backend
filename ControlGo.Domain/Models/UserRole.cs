using System;
using System.Collections.Generic;
using System.Text;

namespace ControlGo.Domain.Models
{
    // Join entity between User and Role
    public class UserRole
    {
        public long Id { get; set; }
        public long TenantId { get; set; }
        public long UserId { get; set; }
        public long RoleId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Tenant Tenant { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
