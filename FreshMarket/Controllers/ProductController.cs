using FreshMarket.Core.Contracts;
using FreshMarket.Core.Models.Product;
using FreshMarket.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FreshMarket.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        private readonly ICreatorService creatorService;

        public ProductController(IProductService _productService, ICreatorService _creatorService)
        {
            productService = _productService;
            creatorService = _creatorService;
        }


        [HttpGet]
        public  async Task<IActionResult> Add()
        {
            if ((await creatorService.ExistById(User.Id())) == false)
            {
                return RedirectToAction(nameof(CreatorController.Become), "Agent");
            }

            var model = new ProductModel()
            {
                ProductCategories = await productService.AllCategories()
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Add(ProductModel model)
        {
            if ((await creatorService.ExistById(User.Id())) == false)
            {
                return RedirectToAction(nameof(CreatorController.Become), "Agent");
            }

            if ((await productService.CategoryExist(model.CategoryId)) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exists");
            }
            if (!ModelState.IsValid)
            {
                model.ProductCategories = await productService.AllCategories();

                return View(model);
            }
            int creatorId = await creatorService.GetCreatorId(User.Id());

            int id = await productService.Create(model, creatorId);

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]AllProductQueryModel query)
        {
            var result = await productService.All(
                query.Category,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllProductQueryModel.ProductPerPage);

            query.TotalProductCount = result.TotalProductCount;
            query.Categories = await productService.AllCategoriesNames();
            query.Products = result.Products;

            return View(query);
        }

        public async Task<IActionResult> Mine()
        {
            var model = new AllProductQueryModel();

            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            if ((await productService.Exists(id) == false))
            {
                return RedirectToAction(nameof(All));
            }

            var model = await productService.ProductDetailsById(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if ((await productService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            if ((await productService.HasCreatorWithId(id, User.Id())) == false)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            var product = await productService.ProductDetailsById(id);
            var categoryId = await productService.GetProductCategoryId(id);

            var model = new ProductModel()
            {
                Id = id,
                Title = product.Title,
                Address = product.Address,
                Price = product.Price,
                CategoryId = categoryId,
                ImageUrl = product.ImageUrl,
                Description = product.Description,
                ProductCategories = await productService.AllCategories()
            };


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductModel model)
        {

            if (id != model.Id)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if ((await productService.Exists(model.Id) == false))
            {
                ModelState.AddModelError("", "Product does not exist");
                model.ProductCategories = await productService.AllCategories();
            }

            if ((await productService.HasCreatorWithId(model.Id, User.Id())) == false)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if ((await productService.CategoryExist(model.CategoryId)) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does noe exist");
                model.ProductCategories = await productService.AllCategories();

                return View(model);
            }

            if (ModelState.IsValid == false)
            {
                model.ProductCategories = await productService.AllCategories();

                return View(model);
            }

            await productService.Edit(model.Id, model);

            return RedirectToAction(nameof(Details), new { model.Id });
        }

        
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if ((await productService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            if((await productService.HasCreatorWithId(id, User.Id())) == false)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            var product = await productService.ProductDetailsById(id);
            var model = new ProductDetailsViewModel()
            {
                Title = product.Title,
                Address = product.Address,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, ProductDetailsViewModel model)
        {
            if ((await productService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            if ((await productService.HasCreatorWithId(id, User.Id())) == false)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            await productService.Delete(id);

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Buy(int id)
        {
            return RedirectToAction(nameof(Mine));
        }
    }
}
