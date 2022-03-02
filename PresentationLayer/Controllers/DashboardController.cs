using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace PresentationLayer.Controllers
{
    public class DashboardController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());

        [AllowAnonymous]
        public IActionResult Index()
        {
            Context context = new Context();
            ViewBag.v1 = context.Blogs.Count();
            ViewBag.v2 = context.Blogs.Where(x => x.WriterID == 1).Count();
            ViewBag.v3 = context.Categories.Count();

            return View();
        }
    }
}
