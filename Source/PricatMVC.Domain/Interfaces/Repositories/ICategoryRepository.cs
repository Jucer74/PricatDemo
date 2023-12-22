using PricatMVC.Domain.Common;
using PricatMVC.Domain.Dtos;
using PricatMVC.Domain.Entities;

namespace PricatMVC.Domain.Interfaces.Repositories;

public interface ICategoryRepository : IRepository<Category>
{
    public Task<QueryResult<Category>> GetByQueryRequest(QueryRequest queryRequest);
}