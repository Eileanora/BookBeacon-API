using BookBeacon.BL.DTOs.BookDTOs;
using BookBeacon.BL.ResourceParameters;
using BookBeacon.Models.Models;

namespace BookBeacon.BL.Helpers.Mappers;

public static class BookMapper
{
    private static BookDto ToListDto(this Book book)
    {
        return new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author.FirstName + " " + book.Author.LastName,
            Summary = book.Summary,
            Category = book.Category.Name,
            Publisher = book.Publisher.Name,
            AvailableCopies = book.Copies.Count(c => c.IsAvailable),
            GenresNames = book.Genres.Select(s => s.Name).ToList(),
        };
    }
    
    public static PagedList<BookDto> ToListDto(this PagedList<Book> books)
    {
        var count = books.TotalCount;
        var pageNumber = books.CurrentPage;
        var pageSize = books.PageSize;
        var totalPages = books.TotalPages;
        return new PagedList<BookDto>(
            books.Select(s => ToListDto(s)).ToList(),
            count,
            pageNumber,
            pageSize,
            totalPages
        );
    }
    
    public static BookDto ToCreatedDto(this Book book)
    {
        return new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            ISBN = book.ISBN,
            Summary = book.Summary,
            PageCount = book.PageCount,
            PublicationDate = book.PublicationDate,
            Edition = book.Edition,
            GenresNames = book.Genres.Select(s => s.Name).ToList(),
            AuthorId = book.AuthorId,
            CategoryId = book.CategoryId,
            PublisherId = book.PublisherId,
        };
    }
    
    
    public static BookDto ToDto(this Book book, IEnumerable<Language?>? languages)
    {
        return new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            ISBN = book.ISBN,
            Summary = book.Summary,
            PageCount = book.PageCount,
            PublicationDate = book.PublicationDate,
            Edition = book.Edition,
            AvailableCopies = book.Copies.Count(c => c.IsAvailable),
            GenresNames = book.Genres.Select(s => s.Name).ToList(),
            Author = book.Author.FirstName + " " + book.Author.LastName,
            Category = book.Category.Name,
            Publisher = book.Publisher.Name,
            Languages = languages?.Select(s => s.Name).ToList(),
        };
    }
    
    public static Book ToCreateEntity(this BookDto bookDto, List<Genre> existingGenres)
    {
        return new Book
        {
            Title = bookDto.Title,
            ISBN = bookDto.ISBN,
            AuthorId = bookDto.AuthorId.GetValueOrDefault(),
            Summary = bookDto.Summary,
            PageCount = bookDto.PageCount.GetValueOrDefault(),
            PublicationDate = bookDto.PublicationDate.GetValueOrDefault(),
            Edition = bookDto.Edition.GetValueOrDefault(),
            CategoryId = bookDto.CategoryId.GetValueOrDefault(),
            PublisherId = bookDto.PublisherId.GetValueOrDefault(),
            Genres = existingGenres.ToList(),
        };
    }
}
