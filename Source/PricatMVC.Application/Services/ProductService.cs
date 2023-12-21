using PricatMVC.Application.Interfaces;
using PricatMVC.Domain.Dtos;
using PricatMVC.Domain.Entities;

namespace PricatMVC.Application.Services;

public class ProductService : IProductService
{
    public Task<Product> Create(Product model)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Product> Edit(Product model)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<QueryResult<Product>> GetByPage(int page, int limit)
    {
        throw new NotImplementedException();
    }
}