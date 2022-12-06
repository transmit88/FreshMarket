using FreshMarket.Core.Contracts;
using FreshMarket.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FreshMarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService productService;

        public HomeController(IProductService productService)
        {
            this.productService = productService;
        }


        //public IActionResult Index() => View();
        public async Task<IActionResult> Index()
        {
            var model = await productService.LastTheeProduct();

            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}