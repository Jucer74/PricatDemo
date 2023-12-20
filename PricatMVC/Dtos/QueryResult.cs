namespace PricatMVC.Dtos;

public class QueryResult<TModel>
{
    public List<TModel> Items { get; set; } = new List<TModel>();
    public PaginationData Pagination { get; set; } = new PaginationData();
}