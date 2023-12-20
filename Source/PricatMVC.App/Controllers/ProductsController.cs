using Microsoft.AspNetCore.Mvc;
using PricatMVC.App.Interfaces;
using PricatMVC.App.Models;

namespace PricatMVC.App.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IService<Product> _productService;

        public ProductsController(IService<Product> productService)
        {
            _productService = productService;
        }

        // GET: ProductsController
        public ActionResult Index()
        {
            var productList = _productService.GetAll();
            return View(productList);
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            var productFound = _productService.GetById(id);

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
        public ActionResult Create(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productService.Create(product);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            var productFound = _productService.GetById(id);

            if (productFound == null)
            {
                return NotFound();
            }

            return View(productFound);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var productFound = _productService.GetById(product.Id);

                    if (productFound == null)
                    {
                        return View();
                    }

                    _productService.Edit(product);

                    return RedirectToAction(nameof(Index));
                }

                return View(product);
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            var productFound = _productService.GetById(id);

            if (productFound == null)
            {
                return NotFound();
            }

            return View(productFound);
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Product product)
        {
            try
            {
                var productFound = _productService.GetById(product.Id);

                if (productFound == null)
                {
                    return NotFound();
                }

                _productService.Delete(product.Id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}