using Microsoft.AspNetCore.Mvc;
using PricatMVC.Application.Interfaces;
using PricatMVC.Application.Services;
using PricatMVC.Domain.Dtos;
using PricatMVC.Domain.Entities;

namespace PricatMVC.App.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: ProductsController
        public async Task<IActionResult> Index(string? sortOrder = null, string? currentFilter = null, string? searchString = null, int? pageNumber = null)
        {
            //var productList = await _productService.GetAll();
            //return View(productList);

            ViewData["CurrentSort"] = sortOrder;
            ViewData["IdSort"] = string.IsNullOrEmpty(sortOrder) ? "Id_DESC" : string.Empty;
            ViewData["DescriptionSort"] = sortOrder == "Description" ? "Description_DESC" : "Description";
            ViewData["EanCodeSort"] = sortOrder == "EanCode" ? "EanCode_DESC" : "EanCode";
            ViewData["PriceSort"] = sortOrder == "Price" ? "Price_DESC" : "Price";
            ViewData["UnitSort"] = sortOrder == "Unit" ? "Unit_DESC" : "Unit";
            ViewData["CurrentFilter"] = searchString;

            if (string.IsNullOrEmpty(searchString))
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;

            int currentPage = pageNumber ?? 1;
            ViewData["CurrentPage"] = currentPage;

            QueryRequest queryRequest = new QueryRequest()
            {
                CurrentPage = currentPage,
                SortOrder = sortOrder,
                SearchString = searchString
            };

            QueryResult<Product> queryResult = await _productService.GetByQueryRequest(queryRequest);
            var productList = queryResult.Items;

            ViewData["PaginationData"] = queryResult.PaginationData;

            return View(productList);

        }

        // GET: ProductsController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var productFound = await _productService.GetById(id);

            if (productFound == null)
            {
                return NotFound();
            }

            return View(productFound);
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productService.Create(product);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: ProductsController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var productFound = await _productService.GetById(id);

            if (productFound == null)
            {
                return NotFound();
            }

            return View(productFound);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var productFound = await _productService.GetById(product.Id);

                if (productFound == null)
                {
                    return View();
                }

                await _productService.Edit(product);

                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        // GET: ProductsController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var productFound = await _productService.GetById(id);

            if (productFound == null)
            {
                return NotFound();
            }

            return View(productFound);
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Product product)
        {
            var productFound = await _productService.GetById(product.Id);

            if (productFound == null)
            {
                return NotFound();
            }

            await _productService.Delete(product.Id);

            return RedirectToAction(nameof(Index));
        }
    }
}