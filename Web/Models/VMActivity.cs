namespace Web.Models
{
    public class VMActivity
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string Location { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Requirements { get; set; } = null!;

        public int ClubId { get; set; }
    }
}
