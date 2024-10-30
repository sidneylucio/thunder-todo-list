using Thunder.ToDoList.Domain.Entities;
using Thunder.ToDoList.Domain.Interfaces;
using Thunder.ToDoList.Infra.Data.Context;

namespace Thunder.ToDoList.Infra.Data.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context) { }
}
