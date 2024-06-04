using Microsoft.AspNetCore.Mvc;
using ProductModel.Models;
using OnLineShop.DB.Models;
using OnLineShop.DB;
using ProductModel.Helpers;
using System;
using System.Collections.Generic;

namespace ProductModel.Controllers
{
    public class AdminController : Controller
    {
        public readonly IGetProducts RepositoryProductDBs;
        private readonly DatabaseContext databaseContext;
        private IGetCarts cartRepository;


        public AdminController(IGetProducts list_ProductDBs, DatabaseContext databaseContext,
            IGetCarts cartRepository)
        {
            this.RepositoryProductDBs = list_ProductDBs;
            this.databaseContext = databaseContext;
            this.cartRepository = cartRepository;
        }



        public IActionResult Orders()
        {
            return View();
        }

        public IActionResult ShowOrders(string userid)
        {
            var cartDb = cartRepository.TryGetByUserId(userid);
            List<string> search = new List<string>();
            foreach (var cartdbItem in cartDb.Products)
            {
                search.Add($" продукт - {cartdbItem.Product.Id} в количистве - {cartdbItem.Amount}");
            }
            return View(search);
        }

        public IActionResult Users()
        {
            return View();
        }

        public IActionResult Roles()
        {
            return View();
        }

        public IActionResult Products()
        {

            return View(Mapping.ListProductDBToListProduct(RepositoryProductDBs.GetProducts()));
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            // если не прошел валидацию возвращаем на ту же вьюшку для редактирования
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            // тут сохранить продукт в product DB
            RepositoryProductDBs.Add(Mapping.ProductToProductDB(product));
            return RedirectToAction("Index", "Product");
        }
    }

}
