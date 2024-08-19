using HW_AspNet_LS2.Entities;
using HW_AspNet_LS2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HW_AspNet_LS2.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public static List<Product> Products = new List<Product>
        {
            new Product
            {
                ID = 1,
                Name = "Coca-Cola",
                Price=1.20,
                Description="This is Coca-Cola",
                Discount=10,
                ImagePath="https://www.thestreet.com/.image/ar_16:9%2Cc_fill%2Ccs_srgb%2Cfl_progressive%2Cq_auto:good%2Cw_1200/MTkxNTY4NjI2MDE5NDc2OTc4/coca-cola-clouds.jpg"
            },
             new Product
            {
                ID = 2,
                Name = "Fanta",
                Price=1.30,
                Description="This is Fanta",
                Discount=11,
                ImagePath="https://cdn.romania-insider.com/sites/default/files/styles/amp_1200x675_16_9/public/2023-01/fanta_juice_-_photo_pixinoo_dreamstime.com_.jpg"
            },
            new Product
            {
                ID = 3,
                Name = "Cappy",
                Price=1.50,
                Description="This is Cappy",
                Discount=12,
                ImagePath="https://gsd.com.mt/wp-content/uploads/2023/02/Cappy-Orange-300x300.jpg"
            },
            new Product
            {
                ID = 4,
                Name = "Sprite",
                Price=1.40,
                Description="This is Sprite",
                Discount=13,
                ImagePath="https://www.urbangroc.com/wp-content/uploads/2021/04/Sprit-Soft-Drink-2-01.jpg"
            },
            new Product
            {
                ID = 5,
                Name = "Redbull",
                Price=3.99,
                Description="This is Redbull",
                Discount=6,
                ImagePath="https://facts.net/wp-content/uploads/2023/05/red-bull.jpg"
            },
            new Product
            {
                ID = 6,
                Name = "Energizer",
                Price=2.60,
                Description="This is Energizer",
                Discount=5,
                ImagePath="https://www.toysrus.com.sg/dw/image/v2/BDGJ_PRD/on/demandware.static/-/Sites-master-catalog-toysrus/default/dwe8bff872/5/0/b/f/50bfb0963555bdf62b95647e95bd20df44a6f6a4_80195_i1.jpg?sw=500&sh=500&q=75"
            }
        };

        public IActionResult Index()
        {
            var allProductsVM = new AllProductsViewModel
            {
                Products = Products
            };
            return View(allProductsVM);
        }

        public IActionResult Delete(int id)
        {
            var product = Products.SingleOrDefault(p => p.ID == id);
            if (product != null)
            {
                Products.Remove(product);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var productForUpdate = Products.SingleOrDefault(p => p.ID == id);
            if (productForUpdate != null)
            {
                var updateProductViewModel = new UpdateProductViewModel
                {
                    ProductForUpdate = productForUpdate
                };
                return View(updateProductViewModel);
            }
            return RedirectToAction("NotFoundPage");
        }

        [HttpPost]
        public IActionResult Update(UpdateProductViewModel updateProductVM)
        {
            if (ModelState.IsValid)
            {
                var productUpdate = Products.SingleOrDefault(p => p.ID == updateProductVM.ProductForUpdate.ID);

                if (productUpdate != null)
                {
                    //productUpdate = updateProductVM.ProductForUpdate;//Is not working
                    productUpdate.Name = updateProductVM.ProductForUpdate.Name;
                    productUpdate.Price = updateProductVM.ProductForUpdate.Price;
                    productUpdate.Description = updateProductVM.ProductForUpdate.Description;
                    productUpdate.Discount = updateProductVM.ProductForUpdate.Discount;
                    productUpdate.ImagePath = updateProductVM.ProductForUpdate.ImagePath;
                    return RedirectToAction("Index");
                }

                //Products.Add(updateProductVM.ProductForUpdate);
                //return RedirectToAction("Index");
            }
            return View(updateProductVM);
            //return RedirectToAction("NotFoundPage");
        }

        [HttpGet]
        public IActionResult Add()
        {
            var addNewProductVM = new AddNewProductViewModel
            {
                NewProduct = new Product()
            };
            return View(addNewProductVM);
        }

        [HttpPost]
        public IActionResult Add(AddNewProductViewModel newProductVM)
        {
            if (ModelState.IsValid)
            {
                newProductVM.NewProduct.ID = Products.Last().ID + 1;
                Products.Add(newProductVM.NewProduct);
                return RedirectToAction("Index");
            }
            return View(newProductVM);
        }


        public IActionResult NotFoundPage()
        {
            return View();
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
