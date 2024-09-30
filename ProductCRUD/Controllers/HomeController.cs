using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ProductCRUD.Models;
using ProductCRUD.Repository;
using System.Diagnostics;

namespace ProductCRUD.Controllers
{
    public class HomeController : Controller
    {

        private readonly IProduct productRepo;

        public HomeController(IProduct product)
        {
            productRepo = product;
        }
                
        public async Task<IActionResult> Index()
        {
            var products = await productRepo.Get();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if(ModelState.IsValid)
            {
                await productRepo.Add(product);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            if(id < 0)
            {
                return NotFound();
            }
            var product = await productRepo.FindById(id);
            if(product == null)
            {
                return NotFound();
            }

            return View("Create", product);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, Product product)
        {
            if(id < 0) {
                return NotFound();
            }
            var tempProduct = await productRepo.FindById(id);
            if(tempProduct == null)
            {
                return BadRequest();
            }
            await productRepo.Update(product);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if(id < 0)
            {
                return NotFound();
            }
            var product = await productRepo.FindById(id);
            if(product == null)
            {
                return BadRequest();
            }
            await productRepo.Delete(product);
            return RedirectToAction(nameof(Index));
        }

    }
}
