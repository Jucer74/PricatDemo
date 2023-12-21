using Microsoft.AspNetCore.Mvc;
using PricatMVC.App.Models;
using PricatMVC.Application.Interfaces;
using PricatMVC.Domain.Entities;

namespace PricatMVC.App.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public CategoriesController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        // GET: CategoriesController
        public async Task<IActionResult> Index()
        {
            var categoryList = await _categoryService.GetAll();
            return View(categoryList);
        }

        // GET: CategoriesController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var categoryFound = await _categoryService.GetById(id);

            if (categoryFound == null)
            {
                return NotFound();
            }

            var productsByCategoryId = await _productService.GetProductsByCategory(id);

            //return RedirectToAction(nameof(Index), "products");

            ProductsByCategory productsByCategory = new()
            {
                CategoryInfo = categoryFound,
                Products = productsByCategoryId.ToList(),
            };


            return View(productsByCategory);
        }

        // GET: CategoriesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.Create(category);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: CategoriesController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var categoryFound = await _categoryService.GetById(id);

            if (categoryFound == null)
            {
                return NotFound();
            }

            return View(categoryFound);
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                var categoryFound = await _categoryService.GetById(category.Id);

                if (categoryFound == null)
                {
                    return View();
                }

                await _categoryService.Edit(category);

                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        // GET: CategoriesController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var categoryFound = await _categoryService.GetById(id);

            if (categoryFound == null)
            {
                return NotFound();
            }

            return View(categoryFound);
        }

        // POST: CategoriesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Category category)
        {
            var categoryFound = await _categoryService.GetById(category.Id);

            if (categoryFound == null)
            {
                return NotFound();
            }

            await _categoryService.Delete(category.Id);

            return RedirectToAction(nameof(Index));
        }
    }
}