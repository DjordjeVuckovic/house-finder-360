namespace HouseFinder360.Application.Common.Pagination;

public class PagedResponse<T>
{
    public IEnumerable<T> Data { get; set; } = null!;
    public Pagination Pagination { get; set; } = null!;
}