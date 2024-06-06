using BookBeacon.API.Helpers.PaginationHelper;
using BookBeacon.BL.DTOs.AuthorDTOs;
using BookBeacon.BL.DTOs.GenreDTOs;
using BookBeacon.BL.Managers.AuthorManager;
using BookBeacon.BL.ResourceParameters;
using FluentValidation;

namespace BookBeacon.API.Helpers.Facades.AuthorControllerFacade;

public interface IAuthorControllerFacade
{
    IAuthorManager AuthorManager { get; }
    IValidator<AuthorDto> AuthorValidator { get; }
    IPaginationHelper<AuthorDto, AuthorResourceParameters> PaginationHelper { get; }
}
