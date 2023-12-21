using PricatMVC.Application.Interfaces;
using PricatMVC.Domain.Dtos;
using PricatMVC.Domain.Entities;
using PricatMVC.Domain.Exceptions;
using PricatMVC.Domain.Interfaces.Repositories;

namespace PricatMVC.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Category> Create(Category model)
    {
        return await _categoryRepository.AddAsync(model);
    }

    public async Task Delete(int id)
    {
        var original = await _categoryRepository.GetByIdAsync(id);

        if (original is not null)
        {
            await _categoryRepository.RemoveAsync(original);
            return;
        }

        throw new NotFoundException($"The Id={id} Not Found");
    }

    public async Task<Category> Edit(Category model)
    {
        var id = model.Id;
        var original = await _categoryRepository.GetByIdAsync(id);

        if (original is not null)
        {
            return await _categoryRepository.UpdateAsync(model);
        }

        throw new NotFoundException($"The Id={id} Not Found");
    }

    public async Task<IEnumerable<Category>> GetAll()
    {
        return await _categoryRepository.GetAllAsync();
    }

    public async Task<Category> GetById(int id)
    {
        var current= await _categoryRepository.GetByIdAsync(id);

        if (current is not null)
        {
            return current;
        }

        throw new NotFoundException($"The Id={id} Not Found");
    }

    public Task<QueryResult<Category>> GetByPage(int page, int limit)
    {
        throw new NotImplementedException();
    }

}