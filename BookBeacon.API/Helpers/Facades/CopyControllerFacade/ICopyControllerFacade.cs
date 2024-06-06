using BookBeacon.API.Helpers.PaginationHelper;
using BookBeacon.BL.DTOs.CopyDTOs;
using BookBeacon.BL.Managers.CopyManager;
using BookBeacon.BL.ResourceParameters;
using FluentValidation;

namespace BookBeacon.API.Helpers.Facades.CopyControllerFacade;

public interface ICopyControllerFacade
{
    IValidator<CopyDto> CopyValidator { get; }
    ICopyManager CopyManager { get; }
    IPaginationHelper<CopyDto, CopyResourceParameters> PaginationHelper { get; }
}
