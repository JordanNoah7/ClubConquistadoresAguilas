namespace Models;

public partial class Club
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public byte Stars { get; set; }

    public DateTime FoundationDate { get; set; }

    public string MeetingDay { get; set; } = null!;

    public TimeSpan MeetingHour { get; set; }

    public string District { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Region { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string Description { get; set; } = null!;

    public object ConcurrencyClub { get; set; } = null!;

    public virtual ICollection<Activity> Activities { get; set; } = new List<Activity>();

    public virtual ICollection<Person> People { get; set; } = new List<Person>();

    public virtual ICollection<Unit> Units { get; set; } = new List<Unit>();
}