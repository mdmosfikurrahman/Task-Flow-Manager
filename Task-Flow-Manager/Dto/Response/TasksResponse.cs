namespace Task_Flow_Manager.Dto.Response;

public class TasksResponse
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Status { get; set; }
    public DateOnly? Duedate { get; set; }
    public long? AssignedToId { get; set; }
    public long? ProjectId { get; set; }
}