namespace Web.Models;

public class VmPerson
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string FullSurname { get; set; } = null;

    public string FathersSurname { get; set; } = null!;

    public string MothersSurname { get; set; } = null!;

    public string BirthDate { get; set; }

    public string Gender { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Class { get; set; } = null!;

    public string Unit { get; set; } = null!;

    public string Position { get; set; } = null!;

    public int ClubId { get; set; }

    public int PersonId { get; set; }

    public IEnumerable<VmPerson> PersonList { get; set; } = new List<VmPerson>();
}