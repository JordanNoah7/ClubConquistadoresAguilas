namespace Models;

public class Specialty
{
    public short Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Requirements { get; set; } = null!;

    public byte CategoryId { get; set; }

    public object ConcurrencySpecialty { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<SpecialtyPerson> SpecialtyPeople { get; set; } = new List<SpecialtyPerson>();
}