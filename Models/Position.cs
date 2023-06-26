namespace Models;

public class Position
{
    public byte Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<PositionPersonActivity> PositionPersonActivities { get; set; } =
        new List<PositionPersonActivity>();

    public virtual ICollection<PositionPersonUnit> PositionPersonUnits { get; set; } = new List<PositionPersonUnit>();
}