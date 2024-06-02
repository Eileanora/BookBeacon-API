using BookBeacon.BL.DTOs.AuthorDTOs;
using BookBeacon.BL.ResourceParameters;
using BookBeacon.Models.Models;

namespace BookBeacon.BL.Helpers.Mappers;

public static class AuthorMapper
{
    private static AuthorDto ToListDto(this Author author)
    {
        return new AuthorDto
        {
            Id = author.Id,
            FullName = author.FirstName + " " + author.LastName,
            Biography = author.Biography
        };
    }
    
    public static PagedList<AuthorDto> ToListDto(this PagedList<Author> authors)
    {
        var count = authors.TotalCount;
        var pageNumber = authors.CurrentPage;
        var pageSize = authors.PageSize;
        var totalPages = authors.TotalPages;
        return new PagedList<AuthorDto>(
            authors.Select(s => ToListDto(s)).ToList(),
            count,
            pageNumber,
            pageSize,
            totalPages
        );
    }
    
    public static AuthorDto ToDto(this Author author)
    {
        return new AuthorDto
        {
            Id = author.Id,
            FullName = author.FirstName + " " + author.LastName,
            Biography = author.Biography
        };
    }
    
    public static Author ToCreateEntity(this AuthorDto authorDto)
    {
        if (authorDto.FullName == null)
            return new Author
            {
                FirstName = authorDto.FirstName,
                LastName = authorDto.LastName,
                Biography = authorDto.Biography
            };
        return new Author
        {
            FirstName = authorDto.FullName.Split(" ")[0],
            LastName = authorDto.FullName.Split(" ")[1],
            Biography = authorDto.Biography
        };
    }
    
    public static void ToUpdateEntity(this AuthorDto authorDto, Author author)
    {
        if (authorDto.FullName == null)
        {
            author.FirstName = authorDto.FirstName;
            author.LastName = authorDto.LastName;
            author.Biography = authorDto.Biography;
            return;
        }
        author.FirstName = authorDto.FullName.Split(" ")[0];
        author.LastName = authorDto.FullName.Split(" ")[1];
        author.Biography = authorDto.Biography;
    }
    
    public static AuthorDto ToUpdateDto(this AuthorDto source)
    {
        var splitName = source.FullName.Split(" ");
        return new AuthorDto
        {
            FirstName = splitName[0],
            LastName = splitName[1],
            Biography = source.Biography
        };
    }
}
