namespace PricatMVC.Domain.Dtos;

public class PaginationData
{
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }

    public int PreviousPage
    {
        get => CurrentPage == 1 ? 1 : CurrentPage - 1;
    }

    public int NextPage
    {
        get => CurrentPage == TotalPages ? TotalPages : CurrentPage + 1;
    }

    public int TotalCount { get; init; }
    public int TotalPages { get; init; }
}