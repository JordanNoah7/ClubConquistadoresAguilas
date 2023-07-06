namespace Models;

public class User
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime? CreationDate { get; set; }

    public object ConcurrencyUser { get; set; } = null!;

    public virtual Person IdNavigation { get; set; } = null!;

    public virtual ICollection<UserPermission> UserPermissions { get; set; } = new List<UserPermission>();

    public virtual ICollection<UserRol> UserRols { get; set; } = new List<UserRol>();
}