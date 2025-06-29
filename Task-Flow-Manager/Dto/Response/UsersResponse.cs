namespace Task_Flow_Manager.Dto.Response;

public class UsersResponse
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public string? Position { get; set; }
    public long? DepartmentId { get; set; }
}