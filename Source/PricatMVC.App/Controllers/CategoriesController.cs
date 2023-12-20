using Microsoft.AspNetCore.Mvc;
using PricatMVC.App.Models;
using PricatMVC.App.Services;

namespace PricatMVC.App.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CategoryService _categoryService;

        public CategoriesController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: CategoriesController
        public ActionResult Index()
        {
            var categoryList = _categoryService.GetAll();
            return View(categoryList);
        }

        // GET: CategoriesController/Details/5
        public ActionResult Details(int id)
        {
            var categoryFound = _categoryService.GetById(id);

            if (categoryFound == null)
            {
                return NotFound();
            }

            var productsByCategory = _categoryService.GetProductsByCategory(id);

            //return RedirectToAction(nameof(Index), "products");

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
        public ActionResult Create(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _categoryService.Create(category);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriesController/Edit/5
        public ActionResult Edit(int id)
        {
            var categoryFound = _categoryService.GetById(id);

            if (categoryFound == null)
            {
                return NotFound();
            }

            return View(categoryFound);
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var categoryFound = _categoryService.GetById(category.Id);

                    if (categoryFound == null)
                    {
                        return View();
                    }

                    _categoryService.Edit(category);

                    return RedirectToAction(nameof(Index));
                }

                return View(category);
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriesController/Delete/5
        public ActionResult Delete(int id)
        {
            var categoryFound = _categoryService.GetById(id);

            if (categoryFound == null)
            {
                return NotFound();
            }

            return View(categoryFound);
        }

        // POST: CategoriesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Category category)
        {
            try
            {
                var categoryFound = _categoryService.GetById(category.Id);

                if (categoryFound == null)
                {
                    return NotFound();
                }

                _categoryService.Delete(category.Id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}