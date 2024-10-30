using MediatR;

namespace Thunder.ToDoList.Application.Commands;

public class DeleteUserCommand : IRequest<bool>
{
    public Guid Id { get; }

    public DeleteUserCommand(Guid id)
    {
        Id = id;
    }
}