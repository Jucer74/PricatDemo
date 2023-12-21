using PricatMVC.Application.Interfaces;
using PricatMVC.Domain.Dtos;
using PricatMVC.Domain.Entities;

namespace PricatMVC.Application.Services;

public class CategoryService : ICategoryService
{
    public Task<Category> Create(Category model)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Category> Edit(Category model)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Category>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Category> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<QueryResult<Category>> GetByPage(int page, int limit)
    {
        throw new NotImplementedException();
    }
}