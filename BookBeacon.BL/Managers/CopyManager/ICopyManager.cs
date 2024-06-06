using BookBeacon.BL.DTOs.CopyDTOs;
using BookBeacon.BL.ResourceParameters;

namespace BookBeacon.BL.Managers.CopyManager;

public interface ICopyManager
{
    Task<PagedList<CopyDto>> GetAllAsync(CopyResourceParameters resourceParameters);
    Task<CopyDto?> GetByIdAsync(int copyId);
    Task<CopyDto?> CreateAsync(CopyDto copyDto);
    Task UpdateAsync(int id, CopyDto copyDto);
    Task<bool> DeleteAsync(int id);
}