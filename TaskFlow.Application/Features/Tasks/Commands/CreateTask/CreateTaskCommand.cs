using MediatR;
using TaskFlow.Application.DTOs;
using TaskFlow.Domain.Enums;

namespace TaskFlow.Application.Features.Tasks.Commands.CreateTask;

public sealed record CreateTaskCommand(
    string Name,
    string? Description,
    TaskState State,
    DateTime? DueTime) : IRequest<TaskItemDto>;
