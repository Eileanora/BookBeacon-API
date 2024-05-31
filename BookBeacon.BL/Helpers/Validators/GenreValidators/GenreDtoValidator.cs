using BookBeacon.BL.DTOs.GenreDTOs;
using BookBeacon.BL.Repositories;
using FluentValidation;

namespace BookBeacon.BL.Helpers.Validators.GenreValidators;

public class GenreDtoValidator : AbstractValidator<GenreDto>
{
    public GenreDtoValidator(
        IGenreRepository genreRepository)
    {
        RuleSet("CreateInput", ()=> {
            RuleFor(x => x.Name).NameValidation();
        });
        
        RuleSet("CreateBusiness", () => {
            RuleFor(x => x.Name)
                .MustAsync(async (name, _) => !await genreRepository.IsNameUnique(name))
                .WithMessage("Genre with this name already exists.");
            
        });
        
        RuleSet("UpdateInput", () => {
            RuleFor(x => x.Name).NameValidation();
        });
        
        RuleSet("UpdateBusiness", () => {
            RuleFor(x => x)
                .MustAsync(async (x, _, context, cancellationToken) =>
                {
                    var existingSystem = await genreRepository.GetByNameAsync(x.Name);
                    var systemId = (int)context.RootContextData["genreId"];
                    return existingSystem == null || existingSystem.Id == systemId;
                })
                .WithMessage("Genre Name already exists.");
        });
    }
}
