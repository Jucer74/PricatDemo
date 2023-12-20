using PricatMVC.Interfaces;
using PricatMVC.Models;
using PricatMVC.Services;
using RestSharp;

namespace PricatMVC.Extensions;

public static class ModulesExtension
{
    public static IServiceCollection AddModules(this IServiceCollection services)
    {
        services.AddSingleton<RestClient>();
        services.AddScoped<CategoryService>();
        //services.AddScoped<IService<Category>, CategoryService>();
        services.AddScoped<IService<Product>, ProductService>();
        return services;
    }
}