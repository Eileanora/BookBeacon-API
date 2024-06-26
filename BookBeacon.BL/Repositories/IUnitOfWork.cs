namespace BookBeacon.BL.Repositories;

public interface IUnitOfWork
{
    Task SaveAsync();
    Task CommitAsync();
    Task RollbackAsync();
}
