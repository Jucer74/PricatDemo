namespace PricatMVC.Domain.Dtos;

public class QueryResult<TModel>
{
    public List<TModel> Items { get; set; } = new List<TModel>();
    public PaginationData PaginationData { get; set; } = new PaginationData();
}