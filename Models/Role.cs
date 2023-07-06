namespace Models;

public class Role
{
    public byte Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime? CreationDate { get; set; }

    public object ConcurrencyRole { get; set; } = null!;

    public virtual ICollection<RolPermission> RolPermissions { get; set; } = new List<RolPermission>();

    public virtual ICollection<UserRol> UserRols { get; set; } = new List<UserRol>();
}