using BookBeacon.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BookBeacon.DAL.DataSeeding;

public class CopiesSeeding
{
    public static void SeedCopies(ModelBuilder modelBuilder)
    {
        var available = true;
        var Id = 1;
        for (int bookId = 1; bookId <= 7; bookId++)
        {
            available = !available;
            for (int copyId = 1; copyId <= 5; copyId++)
            {
                modelBuilder.Entity<Copy>().HasData(
                    new Copy
                    {
                        Id = Id++,
                        IsAvailable = available,
                        Location = $"Shelf {copyId}",
                        Notes = $"Copy {copyId} of Book {bookId}",
                        BookId = bookId,
                        ConditionId = 1 // Assuming '1' is a valid condition ID in your database
                    }
                );
            }
        }
    }
}
