namespace Web.Models;

public class VmPerson
{
    public int Id { get; set; }

    public string Dni { get; set; }

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

    public int ClassId { get; set; }

    public string Unit { get; set; } = null!;

    public int UnitId { get; set; }

    public string Position { get; set; } = null!;

    public int PositionId { get; set; }

    public int RoleId { get; set; }

    public int ClubId { get; set; }

    public int? PersonId { get; set; }

    public byte Total { get; set; }

    public object ConcurrencyPerson { get; set; } = null!;

    public VmUser User { get; set; }

    public IEnumerable<VmPerson> PersonList { get; set; } = new List<VmPerson>();
}