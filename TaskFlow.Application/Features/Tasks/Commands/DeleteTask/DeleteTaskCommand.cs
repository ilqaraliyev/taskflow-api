using MediatR;

namespace TaskFlow.Application.Features.Tasks.Commands.DeleteTask;

public sealed record DeleteTaskCommand(Guid Id) 
    : IRequest<Unit>;
