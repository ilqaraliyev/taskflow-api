using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.Interfaces;

public interface ITaskRepository
{
    Task<List<TaskItem>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<TaskItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task AddAsync(TaskItem taskItem, CancellationToken cancellationToken = default);
    void Update(TaskItem taskItem);
    void Remove(TaskItem taskItem);
}
