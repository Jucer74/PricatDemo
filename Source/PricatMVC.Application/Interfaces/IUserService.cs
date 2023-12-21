namespace PricatMVC.Application.Interfaces;

public interface IUserService<TModel> where TModel : class
{
    public Task<TModel> Register(TModel model);

    public Task<TModel> Login(TModel model);
}