using BookBeacon.Models.Models;

namespace BookBeacon.BL.Repositories;

public interface IBaseRepository <T>
    where T : BaseEntity
{
    public Task<T?> CreateAsync(T entity);
    public T Update(T entity);
    public void Delete(T entity);
    public Task<IEnumerable<T>> GetAllAsync();
}
