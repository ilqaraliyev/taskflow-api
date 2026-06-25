using MediatR;
using TaskFlow.Application.DTOs;

namespace TaskFlow.Application.Features.Tasks.Queries.GetTaskById;

public sealed record GetTaskByIdQuery(Guid Id) 
    : IRequest<TaskItemDto?>;
