using BookBeacon.BL.DTOs.CopyDTOs;
using BookBeacon.BL.Helpers.Facades.CopyManagerFacade;
using BookBeacon.BL.Helpers.Mappers;
using BookBeacon.BL.ResourceParameters;
using FluentValidation;

namespace BookBeacon.BL.Managers.CopyManager;

public class CopyManager : ICopyManager
{
    private readonly ICopyManagerFacade _copyManagerFacade;
    
    public CopyManager(ICopyManagerFacade copyManagerFacade)
    {
        _copyManagerFacade = copyManagerFacade;
    }
    
    public async Task<PagedList<CopyDto>> GetAllAsync(
        CopyResourceParameters resourceParameters)
    {
        var copies = await _copyManagerFacade.CopyRepository
            .GetAllAsync(resourceParameters);

        return copies.ToListDto();
    }

    public async Task<CopyDto?> GetByIdAsync(int copyId)
    {
        var copy = await _copyManagerFacade.CopyRepository
            .GetByIdAsync(copyId);

        return copy?.ToDto();
    }
    
    public async Task<CopyDto?> CreateAsync(CopyDto copyDto)
    {
        var validationResult = await _copyManagerFacade.CopyValidator.ValidateAsync(
            copyDto,
            options => options.IncludeRuleSets("CreateBusiness"));

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var copyToCreate = copyDto.ToCreateEntity();

        var createdCopy = await _copyManagerFacade.CopyRepository
            .CreateAsync(copyToCreate);

        await _copyManagerFacade.UnitOfWork.SaveAsync();
        return createdCopy?.ToCreatedDto();
    }
    
    public async Task UpdateAsync(int id, CopyDto copyDto)
    {
        var validationResult = await _copyManagerFacade.CopyValidator.ValidateAsync(
            copyDto,
            options => options.IncludeRuleSets("UpdateBusiness"));

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var copyToUpdate = await _copyManagerFacade.CopyRepository
            .GetByIdAsync(id);
        if (copyToUpdate == null)
            throw new ValidationException("Copy not found");

        copyToUpdate = copyDto.ToUpdateEntity(copyToUpdate);

        _copyManagerFacade.CopyRepository.Update(copyToUpdate);
        await _copyManagerFacade.UnitOfWork.SaveAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var copy = await _copyManagerFacade.CopyRepository
            .GetByIdAsync(id);
        if (copy == null)
            return false;
        _copyManagerFacade.CopyRepository.Delete(copy);
        await _copyManagerFacade.UnitOfWork.SaveAsync();
        return true;
    }
}
