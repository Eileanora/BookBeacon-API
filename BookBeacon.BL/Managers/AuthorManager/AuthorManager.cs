using BookBeacon.BL.DTOs.AuthorDTOs;
using BookBeacon.BL.Helpers.Facades.AuthorManagerFacade;
using BookBeacon.BL.Helpers.Mappers;
using BookBeacon.BL.ResourceParameters;
using FluentValidation;
using FluentValidation.Internal;

namespace BookBeacon.BL.Managers.AuthorManager;

public class AuthorManager : IAuthorManager
{
    private readonly IAuthorManagerFacade _authorManagerFacade;
    
    public AuthorManager(IAuthorManagerFacade authorManagerFacade)
    {
        _authorManagerFacade = authorManagerFacade;
    }
    
    public async Task<PagedList<AuthorDto>?> GetAllAsync(
        AuthorResourceParameters resourceParameters)
    {
        var authors = await _authorManagerFacade.AuthorRepository
            .GetAllAsync(resourceParameters);

        return authors.ToListDto();
    }
    
    public async Task<AuthorDto?> GetByIdAsync(int id)
    {
        var author = await _authorManagerFacade.AuthorRepository
            .GetByIdAsync(id);
        return author?.ToDto();
    }
    
    public async Task<AuthorDto?> CreateAsync(AuthorDto authorDto)
    {
        var validationResult = await _authorManagerFacade.AuthorValidator
            .ValidateAsync(authorDto,
                options => options.IncludeRuleSets("CreateBusiness"));

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        var authorToCreate = authorDto.ToCreateEntity();
        var createdAuthor = await _authorManagerFacade.AuthorRepository
            .CreateAsync(authorToCreate);
        if (createdAuthor == null)
            return null;
        await _authorManagerFacade.UnitOfWork.SaveAsync();
        return createdAuthor.ToDto();
    }
    
    public async Task UpdateAsync(int id, AuthorDto authorDto)
    {
        var context= new ValidationContext<AuthorDto>(
            authorDto,
            new PropertyChain(),
            new RulesetValidatorSelector(new [] {"UpdateBusiness"}))
        {
            RootContextData =
            {
                ["authorId"] = id
            }
        };
        
        var validationResult = await _authorManagerFacade.AuthorValidator
            .ValidateAsync(context);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        var author = await _authorManagerFacade.AuthorRepository
            .GetByIdAsync(id);
        if (author == null)
            throw new ValidationException("Author not found");
        
        authorDto.ToUpdateEntity(author);
        await _authorManagerFacade.UnitOfWork.SaveAsync();
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        var author = await _authorManagerFacade.AuthorRepository
            .GetByIdAsync(id);
        if (author == null)
            return false;
        
        _authorManagerFacade.AuthorRepository.Delete(author);
        await _authorManagerFacade.UnitOfWork.SaveAsync();
        return true;
    }
}
