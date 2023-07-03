namespace Models;

public partial class UserPermission
{
    public int UserId { get; set; }

    public byte PermissionId { get; set; }

    public object ConcurrencyUp { get; set; } = null!;

    public virtual Permission Permission { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
