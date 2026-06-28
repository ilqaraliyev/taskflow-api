using MediatR;
using TaskFlow.Application.DTOs;
using TaskFlow.Domain.Enums;

namespace TaskFlow.Application.Features.Tasks.Commands.CreateTask;

public record CreateTaskCommand(
    string Name,
    string? Description,
    DateTime? DueTime) : IRequest<TaskItemDto>;
