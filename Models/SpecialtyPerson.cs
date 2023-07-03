namespace Models;

public partial class SpecialtyPerson
{
    public int PersonId { get; set; }

    public short SpecialtyId { get; set; }

    public object ConcurrencySp { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;

    public virtual Specialty Specialty { get; set; } = null!;
}
