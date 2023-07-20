namespace Models;

public class Person
{
    public int Id { get; set; }

    public string Dni { get; set; }

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
    
    public byte Total { get; set; }

    public byte[] ConcurrencyPerson { get; set; } = new byte[8];

    public Attendance Attendance { get; set; } = null;

    public virtual ICollection<ClassPerson> ClassPeople { get; set; } = new List<ClassPerson>();

    public virtual Club Club { get; set; } = null!;

    public virtual ICollection<Person> InversePersonNavigation { get; set; } = new List<Person>();

    public virtual Person? PersonNavigation { get; set; }

    public virtual ICollection<PositionPersonActivity> PositionPersonActivities { get; set; } =
        new List<PositionPersonActivity>();

    public virtual ICollection<PositionPersonUnit> PositionPersonUnits { get; set; } = new List<PositionPersonUnit>();

    public virtual ICollection<SpecialtyPerson> SpecialtyPeople { get; set; } = new List<SpecialtyPerson>();

    public virtual User? User { get; set; }
}