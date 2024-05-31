using BookBeacon.BL.DTOs.GenreDTOs;
using BookBeacon.BL.Repositories;
using BookBeacon.BL.ResourceParameters;

namespace BookBeacon.BL.Managers.GenreManager;

public interface IGenreManager
{
    Task<PagedList<GenreDto>?> GetAllAsync(
        GenreResourceParameters resourceParameters);
    
    Task<GenreDto?> GetByIdAsync(int id);
    
    Task<GenreDto?> CreateAsync(GenreDto genreDto);
    
    Task UpdateAsync(int id, GenreDto genreDto);
    
    Task<bool> DeleteAsync(int id);
    
}
