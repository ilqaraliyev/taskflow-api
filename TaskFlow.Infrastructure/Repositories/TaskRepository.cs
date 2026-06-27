using Microsoft.EntityFrameworkCore;
using TaskFlow.Application.Interfaces;
using TaskFlow.Domain.Entities;
using TaskFlow.Infrastructure.Persistence;

namespace TaskFlow.Infrastructure.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _context;

    public TaskRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(
        TaskItem task, 
        CancellationToken cancellationToken = default)
    {
        await _context.Tasks.AddAsync(task, cancellationToken);  
    }

    public async Task<List<TaskItem>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return await _context.Tasks.ToListAsync(cancellationToken);
    }

    public async Task<TaskItem?> GetByIdAsync(
        Guid id, 
        CancellationToken cancellationToken = default)
    {
        return await _context.Tasks
            .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
    }

    public void Remove(TaskItem taskItem)
    {
        _context.Tasks.Remove(taskItem);
    }

    public void Update(TaskItem taskItem)
    {
        _context.Tasks.Update(taskItem);
    }
}
