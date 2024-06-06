using BookBeacon.API.Helpers.PaginationHelper;
using BookBeacon.BL.DTOs.AuthorDTOs;
using BookBeacon.BL.Managers.AuthorManager;
using BookBeacon.BL.ResourceParameters;
using FluentValidation;

namespace BookBeacon.API.Helpers.Facades.AuthorControllerFacade;

public class AuthorControllerFacade : IAuthorControllerFacade
{
    public IAuthorManager AuthorManager { get; }
    public IValidator<AuthorDto> AuthorValidator { get; }
    public IPaginationHelper<AuthorDto, AuthorResourceParameters> PaginationHelper { get; }

    public AuthorControllerFacade(
        IAuthorManager authorManager,
        IValidator<AuthorDto> authorValidator,
        IPaginationHelper<AuthorDto, AuthorResourceParameters> paginationHelper)
    {
        AuthorManager = authorManager;
        AuthorValidator = authorValidator;
        PaginationHelper = paginationHelper;
    }
}
