namespace Models;

public class Unit
{
    public byte Id { get; set; }

    public string Name { get; set; } = null!;

    public string Motto { get; set; } = null!;

    public string BattleCry { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int ClubId { get; set; }

    public object ConcurrencyUnit { get; set; } = null!;

    public virtual Club Club { get; set; } = null!;

    public virtual ICollection<PositionPersonUnit> PositionPersonUnits { get; set; } = new List<PositionPersonUnit>();
}