namespace Models;

public partial class Class
{
    public byte Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public object ConcurrencyClass { get; set; } = null!;

    public virtual ICollection<ClassPerson> ClassPeople { get; set; } = new List<ClassPerson>();
}