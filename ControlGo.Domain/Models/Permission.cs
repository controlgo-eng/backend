namespace ControlGo.Domain.Models
{
    public class Permission
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<UserPermission> UserPermission { get; set; }
        public ICollection<RolePermission> RolePermission { get; set; } 
    }
}
