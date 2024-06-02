using BookBeacon.BL.DTOs.AuthorDTOs;
using BookBeacon.BL.ResourceParameters;

namespace BookBeacon.BL.Managers.AuthorManager;

public interface IAuthorManager
{
    Task<PagedList<AuthorDto>?> GetAllAsync(
        AuthorResourceParameters resourceParameters);
    
    Task<AuthorDto?> GetByIdAsync(int id);
    
    Task<AuthorDto?> CreateAsync(AuthorDto authorDto);
    
    Task UpdateAsync(int id, AuthorDto authorDto);
    
    Task<bool> DeleteAsync(int id);  
}
