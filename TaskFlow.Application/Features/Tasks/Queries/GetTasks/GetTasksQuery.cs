using MediatR;
using TaskFlow.Application.DTOs;

namespace TaskFlow.Application.Features.Tasks.Queries.GetTasks;

public record GetTasksQuery : IRequest<List<TaskItemDto>>;
