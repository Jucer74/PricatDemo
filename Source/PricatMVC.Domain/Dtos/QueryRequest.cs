namespace PricatMVC.Domain.Dtos;

public class QueryRequest
{
    public int CurrentPage { get; set; } = 1; // Initial Default Page

    public int PageSize { get; set; } = 10; // Default Records By Page

    public string? SortOrder { get; set; } = null!;

    public string? SearchString { get; set; } = null!;
}