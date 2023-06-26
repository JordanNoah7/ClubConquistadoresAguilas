namespace Models;

public class User
{
    public int Id { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public DateTime? CreationDate { get; set; }

    public virtual Person IdNavigation { get; set; } = null!;

    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();

    public virtual ICollection<Role> Rols { get; set; } = new List<Role>();
}