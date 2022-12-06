using FreshMarket.Core.Constants;
using FreshMarket.Core.Contracts;
using FreshMarket.Core.Models.Creator;
using FreshMarket.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FreshMarket.Controllers
{
    [Authorize]
    public class CreatorController : Controller
    {
        private readonly ICreatorService creatorService;

        public CreatorController(ICreatorService _creatorService)
        {
            creatorService = _creatorService;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {

            if (await creatorService.ExistById(User.Id()))
            {
                TempData[MessageConstant.ErrorMessage] = "You are Creator";

                return RedirectToAction("Index", "Home");
            }

            var model = new BecomeCreatorModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeCreatorModel model)
        {
            var userId = User.Id();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await creatorService.ExistById(userId))
            {
                TempData[MessageConstant.ErrorMessage] = "You are Creator";

                return RedirectToAction("Index", "Home");
            }

            if (await creatorService.UserWithPhoneNumberExists(model.PhoneNumber))
            {
                TempData[MessageConstant.ErrorMessage] = "Phone number exist";

                return RedirectToAction("Index", "Home");
            }

            if (await creatorService.UserHasBuy(userId))
            {
                TempData[MessageConstant.ErrorMessage] = "You don't have to have purchases to buy";

                return RedirectToAction("Index", "Home");
            }

            await creatorService.Create(userId, model.PhoneNumber);

            return RedirectToAction("All", "Product");
        }
    }
}
