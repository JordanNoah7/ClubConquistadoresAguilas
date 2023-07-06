namespace Models;

public class PositionPersonActivity
{
    public int ActivityId { get; set; }

    public int PersonId { get; set; }

    public byte PositionId { get; set; }

    public object ConcurrencyPpa { get; set; } = null!;

    public virtual Activity Activity { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;

    public virtual Position Position { get; set; } = null!;
}