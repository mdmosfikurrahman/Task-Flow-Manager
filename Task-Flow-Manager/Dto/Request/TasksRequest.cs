namespace Task_Flow_Manager.Dto.Request;

public class TasksRequest
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Status { get; set; }
    public DateOnly? Duedate { get; set; }
    public long? AssignedToId { get; set; }
    public long? ProjectId { get; set; }
}