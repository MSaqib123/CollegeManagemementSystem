using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class dashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
