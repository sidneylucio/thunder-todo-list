using Thunder.ToDoList.Domain.Entities;

namespace Thunder.ToDoList.Domain.Interfaces;

public interface IRepository<T> where T : Entity
{
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<T> AddAsync(T entity, CancellationToken cancellationToken);
    Task UpdateAsync(T entity, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
}
