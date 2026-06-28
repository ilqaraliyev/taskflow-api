using MediatR;
using TaskFlow.Application.DTOs;

namespace TaskFlow.Application.Features.Tasks.Commands.UpdateTask;

public record UpdateTaskCommand(
    Guid Id,
    string? Name,
    string? Description,
    DateTime? DueTime) : IRequest<TaskItemDto?>;
