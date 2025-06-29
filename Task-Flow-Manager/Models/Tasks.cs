namespace Task_Flow_Manager.Models;

public class Tasks
{
    public long Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? Status { get; set; }

    public DateOnly? Duedate { get; set; }

    public long? AssignedToId { get; set; }

    public long? ProjectId { get; set; }

    public virtual Users? AssignedTo { get; set; }

    public virtual Projects? Project { get; set; }
}