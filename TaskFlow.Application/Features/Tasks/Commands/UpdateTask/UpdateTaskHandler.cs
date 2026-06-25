using MediatR;
using TaskFlow.Application.DTOs;
using TaskFlow.Application.Interfaces;

namespace TaskFlow.Application.Features.Tasks.Commands.UpdateTask;

public sealed class UpdateTaskHandler 
    : IRequestHandler<UpdateTaskCommand, TaskItemDto?>
{
    private readonly ITaskRepository _taskRepository;

    public UpdateTaskHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<TaskItemDto?> Handle(
        UpdateTaskCommand request,
        CancellationToken cancellationToken)
    {
        var taskItem = await _taskRepository.GetByIdAsync(request.Id, cancellationToken);

        if (taskItem is null)
            return null;

        taskItem.Rename(request.Name);
        taskItem.ChangeDescription(request.Description);
        taskItem.ChangeDueTime(request.DueTime);

        _taskRepository.Update(taskItem);

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
