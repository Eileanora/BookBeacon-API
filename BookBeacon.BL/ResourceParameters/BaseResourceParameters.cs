﻿namespace BookBeacon.BL.ResourceParameters;

public abstract class BaseResourceParameters
{
    public string? SearchQuery { get; set; }
    // filters
    public int PageNumber { get; set; } = 1;
    private int _pageSize = 10;
    private const int MaxPageSize = 30;
    
    
    // check if the page size is greater than the max page size, if it is, set it to the max page size
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }
    
    public string? OrderBy { get; set; }
    
}
