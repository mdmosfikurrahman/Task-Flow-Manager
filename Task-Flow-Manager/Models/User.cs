namespace Task_Flow_Manager.Models;

public class User
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Position { get; set; }

    public long? DepartmentId { get; set; }

    public virtual Department? Department { get; set; }

    public virtual ICollection<Project> project { get; set; } = new List<Project>();

    public virtual ICollection<Task> task { get; set; } = new List<Task>();
}