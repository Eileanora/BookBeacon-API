using BookBeacon.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BookBeacon.DAL.DataSeeding;

public class BookLanguageSeeding
{
    public static void SeedBookLanguage(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookLanguage>().HasData(
            new BookLanguage { BookId = 1, LanguageId = 1 },
            new BookLanguage { BookId = 2, LanguageId = 1 },
            new BookLanguage { BookId = 3, LanguageId = 1 },
            new BookLanguage { BookId = 4, LanguageId = 1 },
            new BookLanguage { BookId = 5, LanguageId = 1 },
            new BookLanguage { BookId = 6, LanguageId = 1 },
            new BookLanguage { BookId = 7, LanguageId = 1 },
            new BookLanguage { BookId = 1, LanguageId = 2 },
            new BookLanguage { BookId = 2, LanguageId = 2 },
            new BookLanguage { BookId = 2, LanguageId = 4 },
            new BookLanguage { BookId = 7, LanguageId = 2 }
        );
    }
}
