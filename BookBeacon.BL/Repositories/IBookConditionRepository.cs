using BookBeacon.Models.Models;

namespace BookBeacon.BL.Repositories;

public interface IBookConditionRepository : IBaseRepository<BookCondition>
{
    Task <bool> ConditionExistsAsync(int? conditionId);
}