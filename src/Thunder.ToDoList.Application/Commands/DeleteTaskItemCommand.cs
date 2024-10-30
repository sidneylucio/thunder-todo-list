using MediatR;

namespace Thunder.ToDoList.Application.Commands;

public class DeleteTaskItemCommand : IRequest
{
    public Guid Id { get; set; }

    public DeleteTaskItemCommand(Guid id)
    {
        Id = id;
    }
}
