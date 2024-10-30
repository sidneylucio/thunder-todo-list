using MediatR;
using Thunder.ToDoList.Application.Commands;
using Thunder.ToDoList.Application.DTOs;
using Thunder.ToDoList.Domain.Exceptions;
using Thunder.ToDoList.Domain.Interfaces;

namespace Thunder.ToDoList.Application.Handlers;

public class UpdateTaskItemCommandHandler : IRequestHandler<UpdateTaskItemCommand, TaskItemDto>
{
    private readonly ITaskItemRepository _taskItemRepository;

    public UpdateTaskItemCommandHandler(ITaskItemRepository taskItemRepository)
    {
        _taskItemRepository = taskItemRepository;
    }

    public async Task<TaskItemDto> Handle(UpdateTaskItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await _taskItemRepository.GetByIdAsync(request.Id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException("Task não encontrada.");
        }

        entity.UpdateTask(request.Title, request.Description);

        await _taskItemRepository.UpdateAsync(entity, cancellationToken);

        return new TaskItemDto
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            IsCompleted = entity.IsCompleted,
            DueDate = entity.DueDate,
            UserId = entity.UserId
        };
    }
}
