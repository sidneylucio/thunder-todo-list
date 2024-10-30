using MediatR;
using Thunder.ToDoList.Application.DTOs;

namespace Thunder.ToDoList.Application.Commands;

public class UpdateTaskItemCommand : IRequest<TaskItemDto>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public UpdateTaskItemCommand(Guid id, string title, string description)
    {
        Id = id;
        Title = title;
        Description = description;
    }
}
