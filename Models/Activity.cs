namespace Models;

public class Activity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string Location { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Requirements { get; set; } = null!;

    public int ClubId { get; set; }

    public byte[] ConcurrencyActivity { get; set; } = new byte[8];

    public virtual Club Club { get; set; } = null!;

    public Person Manager { get; set; } = null;

    public virtual ICollection<PositionPersonActivity> PositionPersonActivities { get; set; } =
        new List<PositionPersonActivity>();

    public IEnumerable<Person> Participants { get; set; } = new List<Person>();
    public IEnumerable<Person> NoParticipants { get; set; } = new List<Person>();
}