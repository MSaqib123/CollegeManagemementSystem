using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    public class ContactUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
