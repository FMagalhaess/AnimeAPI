namespace AnimeAPI.Domain.Shared;

public class PaginatedList<T> : List<T>
{
    #region Properties

    public int PageNumber { get; set; }
    public int TotalPages { get; set; }
    public int TotalCount { get; set; }
    public int PageSize { get; set; }
    
    public bool HasPreviousPage => PageNumber > 1;
    public bool HasNextPage => PageNumber < TotalPages;

    #endregion

    #region Constructors

    public PaginatedList(List<T> items, int count, int pageNumber, int pageSize)
        : base(items)
    {
        TotalCount = count;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
    }

    #endregion
    
}