using TaskFlow.Domain.Enums;

namespace TaskFlow.Application.DTOs;

public sealed record TaskItemDto(
    Guid Id,
    string Name,
    string? Description,
    TaskState State,
    DateTime? DueTime,
    DateTime CreatedAt,
    DateTime? UpdatedAt);

