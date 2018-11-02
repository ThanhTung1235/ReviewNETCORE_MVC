using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyNetCoreMVC.Models;

namespace MyNetCoreMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly MyDbContext _context;

        public ProductController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View(_context.Products.ToList());
        }
        
        public IActionResult GetList()
        {
            
            return View();
        }

        public IActionResult Save(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            TempData["Message"] = "Create Succes";
            return Redirect("Index");
        }

        public IActionResult Edit(long id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        public IActionResult Update(Product product)
        {
            var exitProduct = _context.Products.Find(product.id);
            if (exitProduct == null)
            {
                return NotFound();
            }
            exitProduct.name = product.name;
            exitProduct.price = product.price;
            _context.Products.Update(exitProduct);
            _context.SaveChanges();
            return Redirect("Index");
        }

        public IActionResult Delete(long id)
        {
            var exitsProduct = _context.Products.Find(id);
            if (exitsProduct == null)
            {
                return NotFound();
            }

            _context.Products.Remove(exitsProduct);
            _context.SaveChanges();
            return Redirect("Index");
        }

        public IActionResult DeleteAll()
        {

            return Redirect("Index");
        }
    }
}