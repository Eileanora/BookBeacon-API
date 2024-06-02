using BookBeacon.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BookBeacon.DAL.DataSeeding;

public class LanguageSeeding
{
    public static void SeedLanguages(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Language>().HasData(
            new Language { Id = 1, Name = "Arabic" }, // 1
            new Language { Id = 2, Name = "English" }, // 2
            new Language { Id = 3, Name = "Spanish" }, // 3
            new Language { Id = 4, Name = "French" }, // 4
            new Language { Id = 5, Name = "German" }, // 5
            new Language { Id = 6, Name = "Italian" } // 6
        );
    }
}
