using MediatR;
using TaskFlow.Application.DTOs;
using TaskFlow.Application.Interfaces;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.Features.Tasks.Commands.CreateTask;

public sealed class CreateTaskHandler 
    : IRequestHandler<CreateTaskCommand, TaskItemDto>
{
    private readonly ITaskRepository _taskRepository;

    public CreateTaskHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<TaskItemDto> Handle(
        CreateTaskCommand request,
        CancellationToken cancellationToken)
    {
        var taskItem = new TaskItem(
            request.Name,
            request.Description, 
            request.DueTime);

        await _taskRepository.AddAsync(taskItem, cancellationToken);

        return new TaskItemDto(
            taskItem.Id,
            taskItem.Name,
            taskItem.Description,
            taskItem.State,
            taskItem.DueTime,
            taskItem.CreatedAt,
            taskItem.UpdatedAt);
    }
}
