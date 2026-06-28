using MediatR;
using TaskFlow.Application.DTOs;
using TaskFlow.Application.Interfaces;

namespace TaskFlow.Application.Features.Tasks.Commands.ChangeTaskState;

public class ChangeTaskStateHandler : IRequestHandler<ChangeTaskStateCommand, TaskItemDto>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IUnitOfWork _unitOfWork;  

    public ChangeTaskStateHandler(ITaskRepository taskRepository, IUnitOfWork unitOfWork)
    {
        _taskRepository = taskRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<TaskItemDto> Handle(
        ChangeTaskStateCommand request,
        CancellationToken ct)
    {
        var task = await _taskRepository.GetByIdAsync(request.Id, ct);

        if (task is null)
            return null;

        task.ChangeState(request.State);

        _unitOfWork.SaveChangesAsync(ct);

        return new TaskItemDto(
            task.Id,
            task.Name,
            task.Description,
            task.State,
            task.DueTime,
            task.CreatedAt,
            task.UpdatedAt);
    }
}
