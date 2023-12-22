using PricatMVC.Domain.Dtos;

namespace PricatMVC.Application.Common;

public interface IService<TModel> where TModel : class
{
    public Task<TModel> Create(TModel model);

    public Task Delete(int id);

    public Task<TModel> Edit(TModel model);

    public Task<IEnumerable<TModel>> GetAll();

    public Task<TModel> GetById(int id);

    public Task<QueryResult<TModel>> GetByQueryRequest(QueryRequest queryRequest);
}