using MediatR;
using TaskFlow.Application.DTOs;

namespace TaskFlow.Application.Features.Tasks.Queries.GetTasks;

public sealed record GetTasksQuery : IRequest<List<TaskItemDto>>;
