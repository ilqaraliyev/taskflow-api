namespace TaskFlow.API.Contracts.Requests;

public class UpdateTaskRequest
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime? DueTime { get; set; }
}
