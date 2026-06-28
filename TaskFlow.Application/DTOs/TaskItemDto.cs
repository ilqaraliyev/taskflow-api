using TaskFlow.Domain.Enums;

namespace TaskFlow.Application.DTOs;

public record TaskItemDto(
    Guid Id,
    string Name,
    string? Description,
    TaskState State,
    DateTime? DueTime,
    DateTime CreatedAt,
    DateTime? UpdatedAt);

