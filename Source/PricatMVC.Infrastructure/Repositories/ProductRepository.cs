using Microsoft.EntityFrameworkCore;
using PricatMVC.Domain.Dtos;
using PricatMVC.Domain.Entities;
using PricatMVC.Domain.Interfaces.Repositories;
using PricatMVC.Infrastructure.Common;
using PricatMVC.Infrastructure.Context;

namespace PricatMVC.Infrastructure.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    private readonly AppDbContext _appDbContext;
    public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<QueryResult<Product>> GetByQueryRequest(QueryRequest queryRequest)
    {
        var queryItems = _appDbContext.Products.AsQueryable();

        int currentPage = queryRequest.CurrentPage;
        int pageSize = queryRequest.PageSize;

        var itemResult = ApplyCondition(queryItems, queryRequest.SearchString);

        int totalCount = itemResult.Count();
        int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

        var orderedItems = ApplySortOrder(itemResult, queryRequest.SortOrder);

        var items = await orderedItems.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();

        PaginationData paginationData = new()
        {
            CurrentPage = currentPage,
            PageSize = pageSize,
            TotalCount = totalCount,
            TotalPages = totalPages
        };

        QueryResult<Product> queryResult = new()
        {
            Items = items,
            PaginationData = paginationData
        };

        return queryResult;
    }

    private IOrderedQueryable<Product> ApplySortOrder(IQueryable<Product> items, string? sortOrder)
    {
        return sortOrder switch
        {
            "Description_DESC" => items.OrderByDescending(m => m.Description),
            "Description" => items.OrderBy(m => m.Description),
            "EanCode_DESC" => items.OrderByDescending(m => m.EanCode),
            "EanCode" => items.OrderBy(m => m.EanCode),
            "Price_DESC" => items.OrderByDescending(m => m.Price),
            "Price" => items.OrderBy(m => m.Price),
            "Unit_DESC" => items.OrderByDescending(m => m.Unit),
            "Unit" => items.OrderBy(m => m.Unit),
            "Id_DESC" => items.OrderByDescending(m => m.Id),
            _ => items.OrderBy(m => m.Id)
        };
    }

    private IQueryable<Product> ApplyCondition(IQueryable<Product> items, string? searchString)
    {
        if (!string.IsNullOrEmpty(searchString))
        {
            items = items.Where(m => m.Description.Contains(searchString)
                                  || m.EanCode.Contains(searchString)
                                  || m.Unit.Contains(searchString));
        }
        return items;
    }

}