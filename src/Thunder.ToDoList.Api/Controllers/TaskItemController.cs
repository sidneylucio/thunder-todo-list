using MediatR;
using Microsoft.AspNetCore.Mvc;
using Thunder.ToDoList.Api.Filters;
using Thunder.ToDoList.Application.Commands;
using Thunder.ToDoList.Application.DTOs;
using Thunder.ToDoList.Application.Queries;
using Thunder.ToDoList.Application.Validations;

namespace Thunder.ToDoList.Api.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class TaskItemController : ControllerBase
{
    private readonly IMediator _mediator;

    public TaskItemController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<TaskItemDto>), 200)]
    public async Task<ActionResult<IEnumerable<TaskItemDto>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllTaskItemsQuery());
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(TaskItemDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<TaskItemDto>> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetTaskItemByIdQuery(id));
        return result == null ? NotFound() : Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(TaskItemDto), 200)]
    [ProducesResponseType(400)]
    [FluentValidationActionFilter<CreateTaskItemCommand, CreateTaskItemCommandValidator>]
    public async Task<ActionResult<TaskItemDto>> Create([FromBody] CreateTaskItemCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [FluentValidationActionFilter<CreateTaskItemCommand, CreateTaskItemCommandValidator>]
    public async Task<ActionResult> Update([FromBody] UpdateTaskItemCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteTaskItemCommand(id));
        return NoContent();
    }
}
