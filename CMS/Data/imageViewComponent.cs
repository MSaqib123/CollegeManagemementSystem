using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CMS.Data
{
    public class imageViewComponent:ViewComponent
    {
        private readonly cms_06GContext context;
        public imageViewComponent(cms_06GContext context)
        {
            this.context = context;
        }

        public IViewComponentResult Invoke()
        {
            //________ Get Image _____________
            var record = context.TblSlider.ToList().FirstOrDefault();
            return View(record);
        }
    }
}
