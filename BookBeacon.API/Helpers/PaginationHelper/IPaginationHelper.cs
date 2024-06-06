using BookBeacon.BL.ResourceParameters;
using Microsoft.AspNetCore.Mvc;

namespace BookBeacon.API.Helpers.PaginationHelper;

public interface IPaginationHelper<TDto, TResourceParameters>
    where TDto : class
    where TResourceParameters : BaseResourceParameters
{
    void CreateMetaDataHeader(PagedList<TDto> items,
        TResourceParameters resourceParameters,
        IHeaderDictionary responseHeaders,
        IUrlHelper urlHelper,
        string routeName);

    string? CreateResourceUri(
        TResourceParameters resourceParameters,
        string routeName,
        ResourceUriType type,
        IUrlHelper urlHelper);
}
