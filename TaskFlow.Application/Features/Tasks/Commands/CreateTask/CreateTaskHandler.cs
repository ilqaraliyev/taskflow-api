using MediatR;
using TaskFlow.Application.DTOs;
using TaskFlow.Application.Interfaces;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.Features.Tasks.Commands.CreateTask;

public sealed class CreateTaskHandler 
    : IRequestHandler<CreateTaskCommand, TaskItemDto>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateTaskHandler(ITaskRepository taskRepository, IUnitOfWork unitOfWork)
    {
        _taskRepository = taskRepository;
        _unitOfWork = unitOfWork;
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

        await _unitOfWork.SaveChangesAsync(cancellationToken);

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
