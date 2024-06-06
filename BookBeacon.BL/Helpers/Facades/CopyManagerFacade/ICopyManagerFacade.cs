using BookBeacon.BL.DTOs.CopyDTOs;
using BookBeacon.BL.Repositories;
using FluentValidation;

namespace BookBeacon.BL.Helpers.Facades.CopyManagerFacade;

public interface ICopyManagerFacade
{
    IValidator<CopyDto> CopyValidator { get; }
    ICopyRepository CopyRepository { get; }
    IUnitOfWork UnitOfWork { get; }
}
