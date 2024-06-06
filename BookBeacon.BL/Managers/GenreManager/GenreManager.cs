using BookBeacon.BL.DTOs.GenreDTOs;
using BookBeacon.BL.Helpers.Facades.GenreManagerFacade;
using BookBeacon.BL.Helpers.Mappers;
using BookBeacon.BL.ResourceParameters;
using FluentValidation;
using FluentValidation.Internal;

namespace BookBeacon.BL.Managers.GenreManager;

public class GenreManager : IGenreManager
{
    private readonly IGenreManagerFacade _genreManagerFacade;
    public GenreManager(IGenreManagerFacade genreManagerFacade)
    {
        _genreManagerFacade = genreManagerFacade;
    }
    public async Task<PagedList<GenreDto>?> GetAllAsync(GenreResourceParameters resourceParameters)
    {
        var genres = await _genreManagerFacade.GenreRepository
            .GetAllAsync(resourceParameters);
        
        return genres.ToListDto();
    }

    public async Task<GenreDto?> GetByIdAsync(int id)
    {
        var genre = await _genreManagerFacade.GenreRepository
            .GetByIdAsync(id);
        return genre?.ToDto();
    }

    public async Task<GenreDto?> CreateAsync(GenreDto genreDto)
    {
        var validationResult = await _genreManagerFacade.GenreValidator
            .ValidateAsync(genreDto,
                options => options.IncludeRuleSets("CreateBusiness"));

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        var genreToCreate = genreDto.ToCreateEntity();
        var createdGenre = await _genreManagerFacade.GenreRepository
            .CreateAsync(genreToCreate);
        if (createdGenre == null)
            return null;
        await _genreManagerFacade.UnitOfWork.SaveAsync();
        return createdGenre.ToDto();
    }

    public async Task UpdateAsync(int id, GenreDto genreDto)
    {
        var context= new ValidationContext<GenreDto>(
            genreDto,
            new PropertyChain(),
            new RulesetValidatorSelector(new [] {"UpdateBusiness"}))
        {
            RootContextData =
            {
                ["genreId"] = id
            }
        };
        var validationResult = await _genreManagerFacade.GenreValidator
            .ValidateAsync(context);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        var genre = await _genreManagerFacade.GenreRepository
            .GetByIdAsync(id);
        
        genreDto.ToUpdateEntity(genre);
        _genreManagerFacade.GenreRepository.Update(genre);
        await _genreManagerFacade.UnitOfWork.SaveAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var genre = await _genreManagerFacade.GenreRepository
            .GetByIdAsync(id);
        if (genre == null)
            return false;
        _genreManagerFacade.GenreRepository.Delete(genre);
        await _genreManagerFacade.UnitOfWork.SaveAsync();
        return true;
    }
}
