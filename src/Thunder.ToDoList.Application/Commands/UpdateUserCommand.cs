using MediatR;

namespace Thunder.ToDoList.Application.Commands;

public class UpdateUserCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}
