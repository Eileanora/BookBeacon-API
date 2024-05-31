using BookBeacon.BL.Repositories;
using BookBeacon.BL.ResourceParameters;
using BookBeacon.DAL.Context;
using BookBeacon.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BookBeacon.DAL.Repositories;

internal abstract class BaseRepository<T> : IBaseRepository<T>
    where T : BaseEntity
{
    protected readonly BookBeaconContext DbContext;
    protected BaseRepository(BookBeaconContext context)
    {
        DbContext = context;
    }
    public async Task<T?> CreateAsync(T entity)
    {
        var newEntry = await DbContext.Set<T>().AddAsync(entity);
        return newEntry.Entity;
    }

    public T Update(T entity)
    {
        DbContext.Set<T>().Update(entity);
        return entity;
    }

    public void Delete(T entity)
    {
        DbContext.Set<T>().Remove(entity);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await DbContext.Set<T>().ToListAsync();
    }
    
    
    public static async Task<PagedList<T>> CreateAsync(
        IQueryable<T> source, int pageNumber, int pageSize)
    {
        var count = source.Count();
        var items = await source
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return new PagedList<T>(items, count, pageNumber, pageSize);
    }
}
