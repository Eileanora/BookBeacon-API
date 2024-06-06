using BookBeacon.BL.DTOs.GenreDTOs;
using BookBeacon.BL.ResourceParameters;
using BookBeacon.Models.Models;

namespace BookBeacon.BL.Helpers.Mappers;

public static class GenreMapper
{
    private static GenreDto ToListDto(this Genre genre)
    {
        return new GenreDto
        {
            Id = genre.Id,
            Name = genre.Name
        };
    }
    public static PagedList<GenreDto> ToListDto(this PagedList<Genre> genres)
    {
        var count = genres.TotalCount;
        var pageNumber = genres.CurrentPage;
        var pageSize = genres.PageSize;
        var totalPages = genres.TotalPages;
        return new PagedList<GenreDto>(
            genres.Select(s => s.ToListDto()).ToList(),
            count,
            pageNumber,
            pageSize,
            totalPages
        );
    }
    
    public static GenreDto ToDto(this Genre genre)
    {
        return new GenreDto
        {
            Id = genre.Id,
            Name = genre.Name
        };
    }
    
    public static Genre ToCreateEntity(this GenreDto genreDto)
    {
        return new Genre
        {
            Name = genreDto.Name
        };
    }
    
    public static void ToUpdateEntity(this GenreDto genreDto, Genre genre)
    {
        genre.Name = genreDto.Name;
    }
    
    public static GenreDto ToUpdateDto(this GenreDto source)
    {
        return new GenreDto
        {
            Name = source.Name
        };
    }
}
