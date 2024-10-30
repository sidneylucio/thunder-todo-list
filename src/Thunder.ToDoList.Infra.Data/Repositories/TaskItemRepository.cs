using Thunder.ToDoList.Domain.Entities;
using Thunder.ToDoList.Domain.Interfaces;
using Thunder.ToDoList.Infra.Data.Context;

namespace Thunder.ToDoList.Infra.Data.Repositories;

public class TaskItemRepository : Repository<TaskItem>, ITaskItemRepository
{
    public TaskItemRepository(AppDbContext context) : base(context) { }
}
