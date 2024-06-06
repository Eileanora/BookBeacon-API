using BookBeacon.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BookBeacon.DAL.DataSeeding;

public class BookGenreSeeding
{
    public static void SeedBookGenre(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookGenre>().HasData(
            new BookGenre { BookId = 1, GenreId = 1 }, // "Children of Gebelawi" is a Fiction
            new BookGenre { BookId = 1, GenreId = 13 }, // "Children of Gebelawi" is also a Historical Fiction
            new BookGenre { BookId = 2, GenreId = 1 }, // "The Thief and the Dogs" is a Fiction
            new BookGenre { BookId = 2, GenreId = 8 }, // "The Thief and the Dogs" is also a Thriller
            new BookGenre { BookId = 3, GenreId = 1 }, // "Woman at Point Zero" is a Fiction
            new BookGenre { BookId = 3, GenreId = 9 }, // "Woman at Point Zero" is also a Biography
            new BookGenre { BookId = 4, GenreId = 2 }, // "The Hidden Face of Eve" is a Non-Fiction
            new BookGenre { BookId = 4, GenreId = 10 }, // "The Hidden Face of Eve" is also an Autobiography
            new BookGenre { BookId = 5, GenreId = 10 }, // "The Days" is an Autobiography
            new BookGenre { BookId = 5, GenreId = 1 }, // "The Days" is also a Fiction
            new BookGenre { BookId = 6, GenreId = 1 }, // "The Call of the Curlew" is a Fiction
            new BookGenre { BookId = 6, GenreId = 13 }, // "The Call of the Curlew" is also a Historical Fiction
            new BookGenre { BookId = 7, GenreId = 1 }, // "The Map of Love" is a Fiction
            new BookGenre { BookId = 7, GenreId = 7 }  // "The Map of Love" is also a Romance
        );
    }
}
