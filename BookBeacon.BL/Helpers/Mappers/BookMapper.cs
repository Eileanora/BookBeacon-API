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
            AuthorId = book.AuthorId,
            CategoryId = book.CategoryId,
            PublisherId = book.PublisherId,
            GenreIds = book.Genres.Select(s => s.Id).ToList(),
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
    
    public static Book ToUpdateEntity(this BookDto bookDto, Book book)
    {
        book.Title = bookDto.Title;
        book.ISBN = bookDto.ISBN;
        book.Summary = bookDto.Summary;
        book.PageCount = bookDto.PageCount.GetValueOrDefault();
        book.PublicationDate = bookDto.PublicationDate.GetValueOrDefault();
        book.Edition = bookDto.Edition.GetValueOrDefault();
        book.AuthorId = bookDto.AuthorId.GetValueOrDefault();
        book.CategoryId = bookDto.CategoryId.GetValueOrDefault();
        book.PublisherId = bookDto.PublisherId.GetValueOrDefault();
        book.Genres = bookDto.GenreIds.Select(s => new Genre { Id = s }).ToList();
        return book;
    }
    
    public static BookDto ToUpdateDto(this BookDto book)
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
            AuthorId = book.AuthorId,
            CategoryId = book.CategoryId,
            PublisherId = book.PublisherId,
            GenreIds = book.GenreIds,
        };
    }
}
