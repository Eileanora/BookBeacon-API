using BookBeacon.BL.Repositories;
using BookBeacon.DAL.Context;

namespace BookBeacon.DAL.Repositories;

internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly BookBeaconContext _context;
    public UnitOfWork(BookBeaconContext context)
    {
        _context = context;
    }
    public async Task CommitAsync()
    {
        await _context.Database.CommitTransactionAsync();
    }
    
    public async Task RollbackAsync()
    {
        await _context.Database.RollbackTransactionAsync();
    }
    
    public Task SaveAsync()
    {
        return _context.SaveChangesAsync();
    }
}
