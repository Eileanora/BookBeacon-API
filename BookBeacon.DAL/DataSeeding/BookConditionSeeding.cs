using BookBeacon.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BookBeacon.DAL.DataSeeding;

public class BookConditionSeeding
{
    public static void SeedBookConditions(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookCondition>().HasData(
            new BookCondition { Id = 1, Name = "New" },
            new BookCondition { Id = 2, Name = "Like New" },
            new BookCondition { Id = 3, Name = "Very Good" },
            new BookCondition { Id = 4, Name = "Good" },
            new BookCondition { Id = 5, Name = "Acceptable" },
            new BookCondition { Id = 6, Name = "Poor"}
        );
    }
}
