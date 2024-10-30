namespace Thunder.ToDoList.Application.DTOs;

public class TaskItemDto
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime? DueDate { get; set; }
    public Guid UserId { get; set; }
}
