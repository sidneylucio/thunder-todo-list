using MediatR;
using Thunder.ToDoList.Application.DTOs;

namespace Thunder.ToDoList.Application.Commands;

public class CreateUserCommand : IRequest<UserDto>
{
    public string Name { get; set; }
    public string Email { get; set; }
}
