using MediatR;
using TaskFlow.Application.DTOs;
using TaskFlow.Application.Interfaces;

namespace TaskFlow.Application.Features.Tasks.Queries.GetTaskById;

public class GetTaskByIdHandler : IRequestHandler<GetTaskByIdQuery, TaskItemDto?>
{
    private readonly ITaskRepository _taskRepository;

    public GetTaskByIdHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<TaskItemDto?> Handle(
        GetTaskByIdQuery request,
        CancellationToken cancellationToken)
    {
        var taskItem = await _taskRepository.GetByIdAsync(request.Id, cancellationToken);

        if (taskItem is null)
            return null;

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
