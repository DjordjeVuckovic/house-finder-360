namespace HouseFinder360.Application.Common.Pagination;

public class Pagination
{
    private readonly int _currentPage = 1;
    private readonly int _pageSize = 10;
    public int CurrentPage 
    { 
        get => _currentPage;
        init => _currentPage = value > 0 ? value : 1; 
    }
    public int PageSize
    {
        get => _pageSize;
        init => _pageSize = value > 0 ? value : 10;
    }
    public int TotalItems { get; set; }
    public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / PageSize);
}