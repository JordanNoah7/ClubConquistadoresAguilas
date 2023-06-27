namespace Models;

public partial class Permission
{
    public byte Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime? CreationDate { get; set; }

    public object ConcurrencyPermission { get; set; } = null!;

    public virtual ICollection<RolPermission> RolPermissions { get; set; } = new List<RolPermission>();

    public virtual ICollection<UserPermission> UserPermissions { get; set; } = new List<UserPermission>();
}