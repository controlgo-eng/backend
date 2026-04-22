using System;
using System.Collections.Generic;
using System.Text;

namespace ControlGo.Domain.Models
{
    public class TenantSetting
    {
        public long Id { get; set; }
        public long TenantId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Tenant Tenant { get; set; }
    }
}
