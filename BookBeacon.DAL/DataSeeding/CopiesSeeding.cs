using BookBeacon.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BookBeacon.DAL.DataSeeding;

public class CopiesSeeding
{
    public static void SeedCopies(ModelBuilder modelBuilder)
    {
        var available = true;
        var id = 1;
        var languageId = 1;
        for (var bookId = 1; bookId <= 7; bookId++)
        {
            available = !available;
            for (var copyId = 1; copyId <= 5; copyId++)
            {
                modelBuilder.Entity<Copy>().HasData(
                    new Copy
                    {
                        Id = id++,
                        IsAvailable = available,
                        Location = $"Shelf {copyId}",
                        Notes = $"Copy {copyId} of Book {bookId}",
                        BookId = bookId,
                        ConditionId = 1, // Assuming '1' is a valid condition ID in your database
                        LanguageId = (languageId++ % 6) + 1
                    }
                );
            }
        }
    }
}
