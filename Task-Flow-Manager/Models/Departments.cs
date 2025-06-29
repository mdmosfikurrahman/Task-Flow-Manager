namespace Task_Flow_Manager.Models;

public class Departments
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Code { get; set; }

    public string? Location { get; set; }

    public virtual ICollection<Users> user { get; set; } = new List<Users>();
}