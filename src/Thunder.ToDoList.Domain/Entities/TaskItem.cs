namespace Thunder.ToDoList.Domain.Entities;

public class TaskItem : Entity
{

    public string Title { get; private set; }
    public string Description { get; private set; }
    public bool IsCompleted { get; private set; }
    public DateTime? DueDate { get; private set; }

    public Guid UserId { get; private set; }
    public User User { get; private set; }

    public TaskItem(string title, string description, Guid userId, DateTime? dueDate = null)
    {
        Title = title;
        Description = description;
        DueDate = dueDate;
        UserId = userId;
    }

    public void UpdateTask(string title, string description)
    {
        Title = title;
        Description = description;
        SetUpdatedAt();
    }

    public void CompleteTask()
    {
        IsCompleted = true;
        DueDate = DateTime.UtcNow;
        SetUpdatedAt();
    }
}
