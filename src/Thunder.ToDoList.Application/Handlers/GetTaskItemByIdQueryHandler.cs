using MediatR;
using Thunder.ToDoList.Application.DTOs;
using Thunder.ToDoList.Application.Queries;
using Thunder.ToDoList.Domain.Exceptions;
using Thunder.ToDoList.Domain.Interfaces;

namespace Thunder.ToDoList.Application.Handlers;

public class GetTaskItemByIdQueryHandler : IRequestHandler<GetTaskItemByIdQuery, TaskItemDto>
{
    private readonly ITaskItemRepository _taskItemRepository;

    public GetTaskItemByIdQueryHandler(ITaskItemRepository taskItemRepository)
    {
        _taskItemRepository = taskItemRepository;
    }

    public async Task<TaskItemDto> Handle(GetTaskItemByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _taskItemRepository.GetByIdAsync(request.Id, cancellationToken);

        if (result == null)
        {
            throw new NotFoundException("Task não encontrada.");
        }

        return new TaskItemDto
        {
            Id = result.Id,
            Title = result.Title,
            Description = result.Description,
            IsCompleted = result.IsCompleted,
            DueDate = result.DueDate,
            UserId = result.UserId
        };
    }
}
