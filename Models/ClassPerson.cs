namespace Models;

public partial class ClassPerson
{
    public int PersonId { get; set; }

    public byte ClassId { get; set; }

    public object ConcurrencyCp { get; set; } = null!;

    public virtual Class Class { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;
}
