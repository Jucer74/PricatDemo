using PricatMVC.Domain.Common;
using PricatMVC.Domain.Dtos;
using PricatMVC.Domain.Entities;

namespace PricatMVC.Domain.Interfaces.Repositories;

public interface IProductRepository : IRepository<Product>
{
    public Task<QueryResult<Product>> GetByQueryRequest(QueryRequest queryRequest);
}