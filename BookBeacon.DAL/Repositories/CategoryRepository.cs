using BookBeacon.BL.Repositories;
using BookBeacon.DAL.Context;
using BookBeacon.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BookBeacon.DAL.Repositories;

internal class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
   public CategoryRepository(BookBeaconContext DbContext) : base(DbContext)
   {
   }
   
   public async Task<bool> CategoryExistsAsync(int? id)
   {
         return await DbContext.Categories
              .AnyAsync(g => g.Id == id);
   }
}
