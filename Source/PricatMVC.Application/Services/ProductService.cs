using PricatMVC.Application.Interfaces;
using PricatMVC.Domain.Dtos;
using PricatMVC.Domain.Entities;
using PricatMVC.Domain.Exceptions;
using PricatMVC.Domain.Interfaces.Repositories;

namespace PricatMVC.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> Create(Product model)
    {
        return await _productRepository.AddAsync(model);
    }

    public async  Task Delete(int id)
    {
        var original = await _productRepository.GetByIdAsync(id);

        if (original is not null)
        {
            await _productRepository.RemoveAsync(original);
            return;
        }

        throw new NotFoundException($"The Id={id} Not Found");
    }

    public async Task<Product> Edit(Product model)
    {
        var id = model.Id;
        var original = await _productRepository.GetByIdAsync(id);

        if (original is not null)
        {
            return await _productRepository.UpdateAsync(model);
        }

        throw new NotFoundException($"The Id={id} Not Found");
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        return await _productRepository.GetAllAsync();
    }

    public async Task<Product> GetById(int id)
    {
        var current = await _productRepository.GetByIdAsync(id);

        if (current is not null)
        {
            return current;
        }

        throw new NotFoundException($"The Id={id} Not Found");
    }

    public async Task<QueryResult<Product>> GetByQueryRequest(QueryRequest queryRequest)
    {
        return await _productRepository.GetByQueryRequest(queryRequest);
    }

    public async Task<IEnumerable<Product>> GetProductsByCategory(int categoryId)
    {
        return await _productRepository.FindAsync(p => p.CategoryId == categoryId);
    }
}