namespace Models;

public class UserRol
{
    public int UserId { get; set; }

    public byte RolId { get; set; }

    public object ConcurrencyUr { get; set; } = null!;

    public virtual Role Rol { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}