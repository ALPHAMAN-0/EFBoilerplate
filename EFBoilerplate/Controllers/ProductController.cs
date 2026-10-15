using Microsoft.AspNetCore.Mvc;
using EFBoilerplate.EF;
using Microsoft.EntityFrameworkCore;
using EFBoilerplate.Models;

namespace EFBoilerplate.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        // GET /product
        public async Task<IActionResult> Index()
        {
            var products = await _context.product.ToListAsync();
            return View(products);
        }

        // GET /product/details/5
        public IActionResult Details(int id)
        {
            var product = _context.product.FirstOrDefault(s => s.id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // GET /product/create
        public IActionResult Create()
        {
            return View();
        }

        // POST /product/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.product.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET /product/edit/5
        public IActionResult Edit(int id)
        {
            var product = _context.product.FirstOrDefault(s => s.id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST /product/update/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", product);
            }
            var prod = _context.product.FirstOrDefault(s => s.id == id);
            if (prod == null)
            {
                return NotFound();
            }
            prod.name = product.name;
            prod.description = product.description;
            prod.price = product.price;
            prod.stock = product.stock;
            prod.category = product.category;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET /product/delete/5 -> "Are you sure?" page
        public IActionResult Delete(int id)
        {
            var product = _context.product.FirstOrDefault(s => s.id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST /product/delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _context.product.FirstOrDefault(s => s.id == id);
            if (product == null)
            {
                return NotFound();
            }
            _context.product.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
