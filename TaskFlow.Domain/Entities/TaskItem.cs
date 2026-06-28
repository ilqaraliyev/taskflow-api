using TaskFlow.Domain.Common;
using TaskFlow.Domain.Enums;

namespace TaskFlow.Domain.Entities;

public class TaskItem : BaseEntity
{
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public TaskState State { get; private set; }
    public DateTime? DueTime { get; private set; }


    public TaskItem(string name, string? description = null, DateTime? dueTime = null)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be empty", nameof(name));
        }

        if (dueTime.HasValue && dueTime.Value < DateTime.UtcNow)
        {
            throw new InvalidOperationException("Due date cannot be in the past");
        }

        Name = name;
        Description = description;
        DueTime = dueTime;

        State = TaskState.ToDo;
    }

    public void Rename(string name)
    {
        EnsureNotCompleted();

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be empty", nameof(name));
        }

        Name = name;
        UpdatedAt = DateTime.UtcNow;
    }

    public void ChangeState(TaskState newState)
    {
        EnsureNotCompleted();

        State = newState;
        UpdatedAt = DateTime.UtcNow;
    }

    public void ChangeDescription(string? description)
    {
        EnsureNotCompleted();
        Description = description;
        UpdatedAt = DateTime.UtcNow;
    }

    public void ChangeDueTime(DateTime? dueTime)
    {
        if (dueTime.HasValue && dueTime.Value < DateTime.UtcNow)
        {
            throw new InvalidOperationException("Due date cannot be in the past");
        }

        DueTime = dueTime;
        UpdatedAt = DateTime.UtcNow;
    }

    public void EnsureNotCompleted()
    {
        if (State == TaskState.Done)
        {
            throw new InvalidOperationException("Completed task cannot change");
        }
    }
}
