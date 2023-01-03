using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
