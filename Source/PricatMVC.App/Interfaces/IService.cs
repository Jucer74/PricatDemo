using PricatMVC.App.Dtos;

namespace PricatMVC.App.Interfaces;

public interface IService<TModel> where TModel : class
{
    public TModel Create(TModel model);

    public void Delete(int id);

    public TModel Edit(TModel model);

    public List<TModel> GetAll();

    public TModel GetById(int id);

    public QueryResult<TModel> GetByPage(int page, int limit);
}