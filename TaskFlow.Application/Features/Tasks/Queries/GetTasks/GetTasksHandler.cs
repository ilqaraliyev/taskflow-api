using MediatR;
using TaskFlow.Application.DTOs;
using TaskFlow.Application.Interfaces;

namespace TaskFlow.Application.Features.Tasks.Queries.GetTasks;

public class GetTasksHandler : IRequestHandler<GetTasksQuery, List<TaskItemDto>>
{
    private readonly ITaskRepository _taskRepository;

    public GetTasksHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<List<TaskItemDto>> Handle(
        GetTasksQuery request,
        CancellationToken cancellationToken)
    {
        var taskItems = await _taskRepository.GetAllAsync();

        return taskItems.Select(t => new TaskItemDto(
            t.Id,
            t.Name,
            t.Description,
            t.State,
            t.DueTime,
            t.CreatedAt,
            t.UpdatedAt)).ToList();
    }
}
