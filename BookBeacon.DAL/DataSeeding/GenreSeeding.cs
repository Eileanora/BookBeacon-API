using BookBeacon.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BookBeacon.DAL.DataSeeding;

public class GenreSeeding
{
    public static void SeedGenres(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(
            new Genre { Id = 1, Name = "Fiction" }, // 1
            new Genre { Id = 2, Name = "Non-Fiction" }, // 2
            new Genre { Id = 3, Name = "Fantasy" }, // 3
            new Genre { Id = 4, Name = "Science Fiction" }, // 4
            new Genre { Id = 5, Name = "Mystery" }, // 5
            new Genre { Id = 6, Name = "Horror" }, // 6
            new Genre { Id = 7, Name = "Romance" }, // 7
            new Genre { Id = 8, Name = "Thriller" }, // 8
            new Genre { Id = 9, Name = "Biography" }, // 9
            new Genre { Id = 10, Name = "Autobiography" }, // 10
            new Genre { Id = 11, Name = "Self-Help" }, // 11
            new Genre { Id = 12, Name = "Cookbook" }, // 12
            new Genre { Id = 13, Name = "History" }, // 13
            new Genre { Id = 14, Name = "Science" } // 14
        );
    }
}
