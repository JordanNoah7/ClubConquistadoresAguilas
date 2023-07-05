namespace Models;

public class RolPermission
{
    public byte RolId { get; set; }

    public byte PermissionId { get; set; }

    public byte[] ConcurrencyRp { get; set; } = null!;

    public virtual Permission Permission { get; set; } = null!;

    public virtual Role Rol { get; set; } = null!;
}