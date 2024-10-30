using MediatR;
using Thunder.ToDoList.Application.Commands;
using Thunder.ToDoList.Domain.Exceptions;
using Thunder.ToDoList.Domain.Interfaces;

namespace Thunder.ToDoList.Application.Handlers;

public class DeleteTaskItemCommandHandler : IRequestHandler<DeleteTaskItemCommand>
{
    private readonly ITaskItemRepository _taskItemRepository;

    public DeleteTaskItemCommandHandler(ITaskItemRepository taskItemRepository)
    {
        _taskItemRepository = taskItemRepository;
    }

    public async Task Handle(DeleteTaskItemCommand request, CancellationToken cancellationToken)
    {
        var result = await _taskItemRepository.DeleteAsync(request.Id, cancellationToken);

        if (!result)
        {
            throw new NotFoundException("Não foi possível remover a Task.");
        }
    }
}
