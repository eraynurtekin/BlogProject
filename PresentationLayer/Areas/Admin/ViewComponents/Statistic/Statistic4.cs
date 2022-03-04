using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace PresentationLayer.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4 :ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.Name = c.Admins.Where(x => x.AdminID == 1).Select(y => y.Name).FirstOrDefault();
            ViewBag.Image=c.Admins.Where(x=>x.AdminID == 1).Select(y=>y.ImageURL).FirstOrDefault();
            ViewBag.Description = c.Admins.Where(x => x.AdminID == 1).Select(y => y.ShortDescription).FirstOrDefault();
            return View();
        }
    }
}
