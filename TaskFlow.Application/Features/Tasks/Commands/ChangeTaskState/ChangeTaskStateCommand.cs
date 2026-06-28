using MediatR;
using TaskFlow.Application.DTOs;
using TaskFlow.Domain.Enums;

namespace TaskFlow.Application.Features.Tasks.Commands.ChangeTaskState;

public record ChangeTaskStateCommand(Guid Id, TaskState State)
    : IRequest<TaskItemDto>;
