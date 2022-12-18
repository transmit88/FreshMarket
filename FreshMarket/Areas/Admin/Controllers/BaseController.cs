using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FreshMarket.Areas.Admin.Constants.AdminConstants;

namespace FreshMarket.Areas.Admin.Controllers
{
    [Area(AreaName)]
    [Route("Admin/[controller]/[Action]/{id?}")]
    [Authorize(Roles = AdminRoleName)]
    public class BaseController : Controller
    {
    }
}
