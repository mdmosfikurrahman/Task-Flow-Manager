namespace Task_Flow_Manager.Models;

public class Task
{
    public long Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? Status { get; set; }

    public DateOnly? Duedate { get; set; }

    public long? AssignedToId { get; set; }

    public long? ProjectId { get; set; }

    public virtual User? AssignedTo { get; set; }

    public virtual Project? Project { get; set; }
}