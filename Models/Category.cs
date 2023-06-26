namespace Models;

public class Category
{
    public byte Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Specialty> Specialties { get; set; } = new List<Specialty>();
}