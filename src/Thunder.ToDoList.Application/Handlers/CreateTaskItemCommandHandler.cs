using MediatR;
using Thunder.ToDoList.Application.Commands;
using Thunder.ToDoList.Application.DTOs;
using Thunder.ToDoList.Domain.Entities;
using Thunder.ToDoList.Domain.Interfaces;

namespace Thunder.ToDoList.Application.Handlers;

public class CreateTaskItemCommandHandler : IRequestHandler<CreateTaskItemCommand, TaskItemDto>
{
    private readonly ITaskItemRepository _taskItemRepository;

    public CreateTaskItemCommandHandler(ITaskItemRepository taskItemRepository)
    {
        _taskItemRepository = taskItemRepository;
    }

    public async Task<TaskItemDto> Handle(CreateTaskItemCommand request, CancellationToken cancellationToken)
    {
        var taskItem = new TaskItem(request.Title, request.Description, request.UserId, request.DueDate);
        taskItem = await _taskItemRepository.AddAsync(taskItem, cancellationToken);

        return new TaskItemDto
        {
            Id = taskItem.Id,
            Title = taskItem.Title,
            Description = taskItem.Description,
            IsCompleted = taskItem.IsCompleted,
            DueDate = taskItem.DueDate,
            UserId = taskItem.UserId
        };
    }
}
