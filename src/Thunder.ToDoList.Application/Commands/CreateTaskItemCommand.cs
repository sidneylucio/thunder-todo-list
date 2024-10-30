using MediatR;
using Thunder.ToDoList.Application.DTOs;

namespace Thunder.ToDoList.Application.Commands;

public class CreateTaskItemCommand : IRequest<TaskItemDto>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid UserId { get; set; }
    public DateTime? DueDate { get; set; }

    public CreateTaskItemCommand(string title, string description, Guid userId, DateTime? dueDate = null)
    {
        Title = title;
        Description = description;
        UserId = userId;
        DueDate = dueDate;
    }
}
