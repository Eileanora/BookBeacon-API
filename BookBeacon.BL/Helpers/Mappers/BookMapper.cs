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
            Languages = book.Languages.Select(s => s.Name).ToList()
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
    
    public static BookDto ToDto(this Book book)
    {
        return new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            ISBN = book.ISBN,
            Author = book.Author.FirstName + " " + book.Author.LastName,
            Summary = book.Summary,
            PageCount = book.PageCount,
            PublicationDate = book.PublicationDate,
            Edition = book.Edition,
            Category = book.Category.Name,
            Publisher = book.Publisher.Name,
            AvailableCopies = book.Copies.Count(c => c.IsAvailable),
            GenresNames = book.Genres.Select(s => s.Name).ToList(),
            Languages = book.Languages.Select(s => s.Name).ToList(),
        };
    }
    
    public static Book ToCreateEntity(this BookDto bookDto, List<Genre> existingGenres, List<Language> existingLanguages)
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
            Languages = existingLanguages.ToList()
        };
    }
}
