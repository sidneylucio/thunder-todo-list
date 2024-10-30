using MediatR;
using Thunder.ToDoList.Application.DTOs;

namespace Thunder.ToDoList.Application.Queries;

public class GetUserByIdQuery : IRequest<UserDto>
{
    public Guid Id { get; }

    public GetUserByIdQuery(Guid id)
    {
        Id = id;
    }
}
