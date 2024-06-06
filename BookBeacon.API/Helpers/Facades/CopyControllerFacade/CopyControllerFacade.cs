using BookBeacon.API.Helpers.PaginationHelper;
using BookBeacon.BL.DTOs.CopyDTOs;
using BookBeacon.BL.Managers.CopyManager;
using BookBeacon.BL.ResourceParameters;
using FluentValidation;

namespace BookBeacon.API.Helpers.Facades.CopyControllerFacade;

public class CopyControllerFacade : ICopyControllerFacade
{
    public IValidator<CopyDto> CopyValidator { get; }
    public ICopyManager CopyManager { get; }
    public IPaginationHelper<CopyDto, CopyResourceParameters> PaginationHelper { get; }
    
    
    public CopyControllerFacade(
        ICopyManager copyManager,
        IValidator<CopyDto> copyValidator,
        IPaginationHelper<CopyDto, CopyResourceParameters> paginationHelper)
    {
        CopyManager = copyManager;
        CopyValidator = copyValidator;
        PaginationHelper = paginationHelper;
    }
}
