using PricatMVC.Dtos;
using PricatMVC.Interfaces;
using PricatMVC.Models;

namespace PricatMVC.Services;

public class CategoryService : IService<Category>
{
    #region Variables

    private static List<Category> categoryList = InitializeData();

    #endregion Variables

    #region Constructor

    public CategoryService()
    {
    }

    #endregion Constructor

    #region Public-Methods

    public Category Create(Category category)
    {
        return CreateCategory(category);
    }

    public void Delete(int id)
    {
        RemoveCategory(id);
    }

    public Category Edit(Category category)
    {
        return EditCategory(category);
    }

    public List<Category> GetAll()
    {
        return GetAllCategories();
    }

    public Category GetById(int id)
    {
        return GetCategoryById(id);
    }

    public QueryResult<Category> GetByPage(int page, int limit)
    {
        var categoryList = GetCategoriesByPage(page, limit);

        var queryResult = new QueryResult<Category>()
        {
            Items = categoryList,
            Pagination = new PaginationData()
            {
                Page = page,
                Limit = limit
            }
        };

        return queryResult;
    }

    public ProductsByCategory GetProductsByCategory(int id)
    {
        var categoryInfo = GetCategoryById(id);
        var products = GetProductsCategoryById(id);

        return new ProductsByCategory()
        {
            CategoryInfo = categoryInfo,
            Products = products
        };
    }

    #endregion Public-Methods

    #region Private-Methods

    private static List<Category> InitializeData()
    {
        var categories = new List<Category>()
        {
            new Category(){Id= 1, Description= "Alimentos"},
            new Category(){Id= 2, Description= "Bebidas"},
            new Category(){Id= 3, Description= "Productos de Aseo"},
            new Category(){Id= 4, Description= "Ropa"},
            new Category(){Id= 5, Description= "Medicamentos"},
            new Category(){Id= 6, Description= "Herramientas"},
            new Category(){Id= 7, Description= "Frutas"},
            new Category(){Id= 8, Description= "Joyeria"},
            new Category(){Id= 9, Description= "Tecnologia"},
            new Category(){Id= 10,Description= "Jugueteria"},
            new Category(){Id= 11,Description= "Mascotas"},
            new Category(){Id= 12,Description= "Zapatos"}
        };

        return categories;
    }

    private Category CreateCategory(Category category)
    {
        throw new NotImplementedException();

        //var request = new RestRequest($"{baseUrl}/{resourceName}", Method.Post);
        //request.AddJsonBody(category);
        //var response = await _restClient.PostAsync(request);

        //Category? data = JsonConvert.DeserializeObject<Category>(response.Content!);

        //return data!;
    }

    private Category EditCategory(Category category)
    {
        throw new NotImplementedException();

        //var request = new RestRequest($"{baseUrl}/{resourceName}/{category.Id}", Method.Put);
        //request.AddJsonBody(category);

        //var response = await _restClient.PutAsync(request);

        //Category? data = JsonConvert.DeserializeObject<Category>(response.Content!);

        //return data!;
    }

    private List<Category> GetAllCategories()
    {
        return categoryList;

        //var request = new RestRequest($"{baseUrl}/{resourceName}", Method.Get);
        //var response = await _restClient.GetAsync(request);

        //List<Category>? data = JsonConvert.DeserializeObject<List<Category>>(response.Content!);

        //return data!;
    }

    private List<Category> GetCategoriesByPage(int page, int limit)
    {
        throw new NotImplementedException();

        //var request = new RestRequest($"{baseUrl}/{resourceName}?_page={page}&_limit={limit}", Method.Get);
        //var response = await _restClient.GetAsync(request);

        //List<Category>? data = JsonConvert.DeserializeObject<List<Category>>(response.Content!);

        //return data!;
    }

    private Category GetCategoryById(int id)
    {
        throw new NotImplementedException();

        //var request = new RestRequest($"{baseUrl}/{resourceName}/{id}", Method.Get);

        //var response = await _restClient.GetAsync(request);

        //Category? data = JsonConvert.DeserializeObject<Category>(response.Content!);

        //return data!;
    }

    private async Task<bool> RemoveCategory(int id)
    {
        throw new NotImplementedException();

        //var request = new RestRequest($"{baseUrl}/{resourceName}/{id}", Method.Delete);

        //var response = await _restClient.DeleteAsync(request);

        //return response.IsSuccessStatusCode;
    }

    private List<Product> GetProductsCategoryById(int id)
    {
        throw new NotImplementedException();

        //var request = new RestRequest($"{baseUrl}/{resourceName}/{id}/products", Method.Get);

        //var response = await _restClient.GetAsync(request);

        //List<Product>? data = JsonConvert.DeserializeObject<List<Product>>(response.Content!);

        //return data!;
    }

    #endregion Private-Methods
}