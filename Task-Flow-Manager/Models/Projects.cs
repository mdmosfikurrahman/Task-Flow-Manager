namespace Task_Flow_Manager.Models;

public class Projects
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public long? ManagerId { get; set; }

    public virtual Users? Manager { get; set; }

    public virtual ICollection<Tasks> task { get; set; } = new List<Tasks>();
}