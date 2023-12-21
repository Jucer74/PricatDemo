using PricatMVC.Domain.Entities;
using PricatMVC.Domain.Interfaces.Repositories;
using PricatMVC.Infrastructure.Common;
using PricatMVC.Infrastructure.Context;

namespace PricatMVC.Infrastructure.Repositories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}