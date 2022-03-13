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
        Context context = new Context();

        public IActionResult Index()
        {
            var username = User.Identity.Name;
            var usermail = context.Users.Where(x => x.UserName ==username).Select(y=>y.Email).FirstOrDefault();
            var writerid = context.Writers.Where(x=>x.WriterMail == usermail).Select(y=>y.WriterID).FirstOrDefault();

            
            ViewBag.v1 = context.Blogs.Count();
            ViewBag.v2 = context.Blogs.Where(x => x.WriterID == writerid).Count();
            ViewBag.v3 = context.Categories.Count();


           
            


            return View();
        }
    }
}
