namespace Task_Flow_Manager.Models;

public class Users
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Position { get; set; }

    public long? DepartmentId { get; set; }

    public virtual Departments? Department { get; set; }

    public virtual ICollection<Projects> project { get; set; } = new List<Projects>();

    public virtual ICollection<Tasks> task { get; set; } = new List<Tasks>();
}