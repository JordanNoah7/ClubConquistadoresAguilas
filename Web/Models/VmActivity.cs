namespace Web.Models;

public class VmActivity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string StartDate { get; set; } = null!;

    public string EndDate { get; set; } = null!;

    public string Location { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Requirements { get; set; } = null!;

    public int ClubId { get; set; }
}