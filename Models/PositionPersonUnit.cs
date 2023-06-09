﻿namespace Models;

public class PositionPersonUnit
{
    public byte UnitId { get; set; }

    public int PersonId { get; set; }

    public byte PositionId { get; set; }

    public object ConcurrencyPpu { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;

    public virtual Position Position { get; set; } = null!;

    public virtual Unit Unit { get; set; } = null!;
}