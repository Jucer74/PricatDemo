using Microsoft.EntityFrameworkCore;
using PricatMVC.Domain.Dtos;
using PricatMVC.Domain.Entities;
using PricatMVC.Domain.Interfaces.Repositories;
using PricatMVC.Infrastructure.Common;
using PricatMVC.Infrastructure.Context;

namespace PricatMVC.Infrastructure.Repositories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    private readonly AppDbContext _appDbContext;

    public CategoryRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<QueryResult<Category>> GetByQueryRequest(QueryRequest queryRequest)
    {
        var queryItems = _appDbContext.Categories.AsQueryable();

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

        QueryResult<Category> queryResult = new()
        {
            Items = items,
            PaginationData = paginationData
        };

        return queryResult;
    }

    private IOrderedQueryable<Category> ApplySortOrder(IQueryable<Category> items, string? sortOrder)
    {
        return sortOrder switch
        {
            "Description_DESC" => items.OrderByDescending(m => m.Description),
            "Description" => items.OrderBy(m => m.Description),
            "Id_DESC" => items.OrderByDescending(m => m.Id),
            _ => items.OrderBy(m => m.Id)
        };
    }

    private IQueryable<Category> ApplyCondition(IQueryable<Category> items, string? searchString)
    {
        if (!string.IsNullOrEmpty(searchString))
        {
            items = items.Where(m => m.Description.Contains(searchString));
        }
        return items;
    }

}