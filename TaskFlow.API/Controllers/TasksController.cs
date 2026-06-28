using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.API.Contracts.Requests;
using TaskFlow.Application.DTOs;
using TaskFlow.Application.Features.Tasks.Commands.ChangeTaskState;
using TaskFlow.Application.Features.Tasks.Commands.CreateTask;
using TaskFlow.Application.Features.Tasks.Commands.DeleteTask;
using TaskFlow.Application.Features.Tasks.Commands.UpdateTask;
using TaskFlow.Application.Features.Tasks.Queries.GetTaskById;
using TaskFlow.Application.Features.Tasks.Queries.GetTasks;
using TaskFlow.Domain.Enums;

namespace TaskFlow.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    private readonly IMediator _mediator;

    public TasksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<TaskItemDto>> Create(CreateTaskCommand command, CancellationToken ct)
    {
        var result = await _mediator.Send(command, ct);

        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<List<TaskItemDto>>> GetAll(CancellationToken ct)
    {
        var result = await _mediator.Send(new GetTasksQuery(), ct);

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<TaskItemDto>> GetById(Guid id, CancellationToken ct)
    {
        var result = await _mediator.Send(new GetTaskByIdQuery(id), ct);

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpPatch("{id:guid}")]
    public async Task<ActionResult<TaskItemDto>> Update(Guid id, UpdateTaskRequest request, CancellationToken ct)
    {
        var command = new UpdateTaskCommand(
            id, 
            request.Name, 
            request.Description, 
            request.DueTime
        );

        var result = await _mediator.Send(command, ct);

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpPatch("{id:guid}/state")]
    public async Task<ActionResult<TaskItemDto>> ChangeState(Guid id, TaskState state, CancellationToken ct)
    {
        var command = new ChangeTaskStateCommand(id, state);

        var result = await _mediator.Send(command);

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        await _mediator.Send(new DeleteTaskCommand(id), ct);

        return NoContent();
    }
}
