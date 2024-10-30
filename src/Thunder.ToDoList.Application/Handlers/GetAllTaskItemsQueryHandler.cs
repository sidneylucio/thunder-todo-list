using MediatR;
using Thunder.ToDoList.Application.DTOs;
using Thunder.ToDoList.Application.Queries;
using Thunder.ToDoList.Domain.Interfaces;

namespace Thunder.ToDoList.Application.Handlers;

public class GetAllTaskItemsQueryHandler : IRequestHandler<GetAllTaskItemsQuery, IEnumerable<TaskItemDto>>
{
    private readonly ITaskItemRepository _taskItemRepository;

    public GetAllTaskItemsQueryHandler(ITaskItemRepository taskItemRepository)
    {
        _taskItemRepository = taskItemRepository;
    }

    public async Task<IEnumerable<TaskItemDto>> Handle(GetAllTaskItemsQuery request, CancellationToken cancellationToken)
    {
        var taskItems = await _taskItemRepository.GetAllAsync(cancellationToken);
        return taskItems.Select(task => new TaskItemDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            IsCompleted = task.IsCompleted,
            DueDate = task.DueDate,
            UserId = task.UserId
        });
    }
}
