using FreshMarket.Core.Contracts;
using FreshMarket.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static FreshMarket.Areas.Admin.Constants.AdminConstants;

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
            if (User.IsInRole(AdminRoleName))
            {
                return RedirectToAction("Index", "Admin", new { area = "Admin" });
            }

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