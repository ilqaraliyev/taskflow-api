using MediatR;
using TaskFlow.Application.Interfaces;

namespace TaskFlow.Application.Features.Tasks.Commands.DeleteTask;

public sealed class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand, Unit>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTaskHandler(ITaskRepository taskRepository, IUnitOfWork unitOfWork)
    {
        _taskRepository = taskRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(
        DeleteTaskCommand request,
        CancellationToken cancellationToken)
    {
        var taskItem = await _taskRepository.GetByIdAsync(request.Id, cancellationToken);

        if (taskItem is null)
            return Unit.Value;

        _taskRepository.Remove(taskItem);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
