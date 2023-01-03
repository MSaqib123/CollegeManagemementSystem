using CMS.Data;
using CMS.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CMS.Controllers
{
    public class FacilityController : Controller
    {
        private readonly cms_06GContext context;
        private readonly IWebHostEnvironment iWebHost;
        private readonly UserManager<ApplicationUser> userManager;
        public FacilityController(cms_06GContext context, IWebHostEnvironment iWebHost, UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
            this.context = context;
            this.iWebHost = iWebHost;
        }

        public IActionResult Index()
        {
            var list = context.TblFacilities.Include(x => x.Dep).ToList();
            return View(list);
        }

    }
}
