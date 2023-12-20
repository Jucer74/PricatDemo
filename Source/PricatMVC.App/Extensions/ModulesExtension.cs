using PricatMVC.App.Interfaces;
using PricatMVC.App.Models;
using PricatMVC.App.Services;

namespace PricatMVC.App.Extensions;

public static class ModulesExtension
{
    public static IServiceCollection AddModules(this IServiceCollection services)
    {
        services.AddScoped<IService<Category>, CategoryService>();
        services.AddScoped<IService<Product>, ProductService>();
        return services;
    }
}