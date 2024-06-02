using BookBeacon.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BookBeacon.DAL.DataSeeding;

public class CategorySeeding
{
    public static void SeedCategories(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Short Story" }, // 1
            new Category { Id = 2, Name = "Novel" }, // 2
            new Category { Id = 3, Name = "Child Book" }, // 3
            new Category { Id = 4, Name = "Poetry" }, // 4
            new Category { Id = 5, Name = "Comic" }, // 5
            new Category { Id = 6, Name = "Book" }, // 6
            new Category { Id = 7, Name  = "Autobiography" } // 7
        );
    }
}
