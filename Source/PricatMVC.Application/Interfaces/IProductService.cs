using PricatMVC.Application.Common;
using PricatMVC.Domain.Entities;

namespace PricatMVC.Application.Interfaces;

public interface IProductService : IService<Product>
{
    public Task<IEnumerable<Product>> GetProductsByCategory(int categoryId);
}