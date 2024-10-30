using MediatR;
using Thunder.ToDoList.Application.DTOs;

namespace Thunder.ToDoList.Application.Queries;

public class GetTaskItemByIdQuery : IRequest<TaskItemDto>
{
    public Guid Id { get; set; }

    public GetTaskItemByIdQuery(Guid id)
    {
        Id = id;
    }
}
