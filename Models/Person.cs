namespace Models;

public class Person
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string FathersSurname { get; set; } = null!;

    public string MothersSurname { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public string Gender { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int ClubId { get; set; }

    public int? PersonId { get; set; }

    public virtual Club Club { get; set; } = null!;

    public virtual ICollection<Person> InversePersonNavigation { get; set; } = new List<Person>();

    public virtual Person? PersonNavigation { get; set; }

    public virtual ICollection<PositionPersonActivity> PositionPersonActivities { get; set; } =
        new List<PositionPersonActivity>();

    public virtual ICollection<PositionPersonUnit> PositionPersonUnits { get; set; } = new List<PositionPersonUnit>();

    public virtual User? User { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Specialty> Specialties { get; set; } = new List<Specialty>();
}