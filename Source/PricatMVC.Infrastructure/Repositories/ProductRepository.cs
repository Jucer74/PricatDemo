using PricatMVC.Domain.Entities;
using PricatMVC.Domain.Interfaces.Repositories;
using PricatMVC.Infrastructure.Common;
using PricatMVC.Infrastructure.Context;

namespace PricatMVC.Infrastructure.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}