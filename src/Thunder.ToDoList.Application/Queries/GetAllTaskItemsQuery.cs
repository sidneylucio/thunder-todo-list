using MediatR;
using Thunder.ToDoList.Application.DTOs;

namespace Thunder.ToDoList.Application.Queries;

public class GetAllTaskItemsQuery : IRequest<IEnumerable<TaskItemDto>>
{
}
