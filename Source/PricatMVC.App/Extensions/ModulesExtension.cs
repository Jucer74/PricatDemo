using PricatMVC.Application.Interfaces;
using PricatMVC.Application.Services;
using PricatMVC.Domain.Entities;
using PricatMVC.Domain.Interfaces.Repositories;
using PricatMVC.Infrastructure.Repositories;

namespace PricatMVC.App.Extensions;

public static class ModulesExtension
{
    public static IServiceCollection AddModules(this IServiceCollection services)
    {
        // Add Repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();

        // Add Services After Repositories
        services.AddScoped<IUserService<User>, UserService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();

        return services;
    }
}