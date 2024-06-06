using BookBeacon.Models.Models;

namespace BookBeacon.BL.Repositories;

public interface IPublisherRepository : IBaseRepository<Publisher>
{
    Task<bool> PublisherExistsAsync(int? id);
}