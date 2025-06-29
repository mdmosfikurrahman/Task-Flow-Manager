namespace Task_Flow_Manager.Dto.Request;

public class ProjectsRequest
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public long? ManagerId { get; set; }
}