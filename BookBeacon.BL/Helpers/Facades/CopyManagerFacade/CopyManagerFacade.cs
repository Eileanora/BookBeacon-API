using BookBeacon.BL.DTOs.CopyDTOs;
using BookBeacon.BL.Repositories;
using FluentValidation;

namespace BookBeacon.BL.Helpers.Facades.CopyManagerFacade;

public class CopyManagerFacade : ICopyManagerFacade
{
    public IValidator<CopyDto> CopyValidator { get; }
    public ICopyRepository CopyRepository { get; }
    public IUnitOfWork UnitOfWork { get; }
    
    public CopyManagerFacade(
        IValidator<CopyDto> copyValidator,
        ICopyRepository copyRepository,
        IUnitOfWork unitOfWork)
    {
        CopyValidator = copyValidator;
        CopyRepository = copyRepository;
        UnitOfWork = unitOfWork;
    }
}
