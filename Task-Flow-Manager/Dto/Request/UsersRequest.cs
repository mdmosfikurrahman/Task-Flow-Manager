namespace Task_Flow_Manager.Dto.Request;

public class UsersRequest
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public string? Position { get; set; }
    public long DepartmentId { get; set; }
}