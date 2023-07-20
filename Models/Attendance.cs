namespace Models;

public class Attendance
{
    public int PersonId { get; set; }
    public DateTime Date { get; set; }
    public byte Frecuency { get; set; }
    public byte Devotion { get; set; }
    public byte Monthly { get; set; }
    public byte Discipline { get; set; }
    public byte Year { get; set; }
    public byte Requeriments { get; set; }
}