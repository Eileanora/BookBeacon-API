using BookBeacon.BL.DTOs.CopyDTOs;
using BookBeacon.BL.ResourceParameters;
using BookBeacon.Models.Models;

namespace BookBeacon.BL.Helpers.Mappers;

public static class CopyMapper
{
    private static CopyDto ToListDto(this Copy copy)
    {
        return new CopyDto
        {
            Id = copy.Id,
            IsAvailable = copy.IsAvailable,
            ConditionName = copy.Condition.Name,
            Location = copy.Location,
            Notes = copy.Notes,
            LanguageName = copy.Language.Name,
            LanguageId = copy.LanguageId
        };
    }
    
    public static PagedList<CopyDto> ToListDto(this PagedList<Copy> copies)
    {
        var count = copies.TotalCount;
        var pageNumber = copies.CurrentPage;
        var pageSize = copies.PageSize;
        var totalPages = copies.TotalPages;
        return new PagedList<CopyDto>(
            copies.Select(s => ToListDto(s)).ToList(),
            count,
            pageNumber,
            pageSize,
            totalPages
        );
    }
    
    public static CopyDto ToDto(this Copy copy)
    {
        return new CopyDto
        {
            Id = copy.Id,
            BookId = copy.BookId,
            IsAvailable = copy.IsAvailable,
            ConditionId = copy.ConditionId,
            ConditionName = copy.Condition.Name,
            Location = copy.Location,
            Notes = copy.Notes,
            LanguageId = copy.LanguageId,
            LanguageName = copy.Language.Name
        };
    }
    
    public static CopyDto ToPatchDto(this Copy copy)
    {
        return new CopyDto
        {
            Id = copy.Id,
            IsAvailable = copy.IsAvailable,
            ConditionId = copy.ConditionId,
            Location = copy.Location,
            Notes = copy.Notes,
            LanguageId = copy.LanguageId
        };
    }
    
    public static Copy ToCreateEntity(this CopyDto copyDto)
    {
        return new Copy
        {
            Id = copyDto.Id.GetValueOrDefault(),
            IsAvailable = copyDto.IsAvailable.GetValueOrDefault(),
            ConditionId = copyDto.ConditionId.GetValueOrDefault(),
            Location = copyDto.Location,
            Notes = copyDto.Notes,
            BookId = copyDto.BookId,
            LanguageId = copyDto.LanguageId.GetValueOrDefault()
        };
    }
    
    public static CopyDto ToCreatedDto(this Copy copy)
    {
        return new CopyDto
        {
            Id = copy.Id,
            IsAvailable = copy.IsAvailable,
            ConditionId = copy.ConditionId,
            Location = copy.Location,
            Notes = copy.Notes,
            BookId = copy.BookId,
            LanguageId = copy.LanguageId
        };
    }
    
    public static Copy ToUpdateEntity(this CopyDto copyDto, Copy copy)
    {
        copy.IsAvailable = copyDto.IsAvailable.GetValueOrDefault();
        copy.ConditionId = copyDto.ConditionId.GetValueOrDefault();
        copy.Location = copyDto.Location;
        copy.Notes = copyDto.Notes;
        copy.BookId = copyDto.BookId;
        copy.LanguageId = copyDto.LanguageId.GetValueOrDefault();
        return copy;
    }
    
    public static CopyDto ToUpdateDto(this CopyDto source)
    {
        return new CopyDto
        {
            Id = source.Id,
            BookId = source.BookId,
            IsAvailable = source.IsAvailable,
            ConditionId = source.ConditionId,
            Location = source.Location,
            Notes = source.Notes,
            LanguageId = source.LanguageId
        };
    }
}
