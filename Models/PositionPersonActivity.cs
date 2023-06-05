using System;
using System.Collections.Generic;

namespace Models;

public partial class PositionPersonActivity
{
    public int ActivityId { get; set; }

    public int PersonId { get; set; }

    public byte PositionId { get; set; }

    public virtual Activity Activity { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;

    public virtual Position Position { get; set; } = null!;
}
