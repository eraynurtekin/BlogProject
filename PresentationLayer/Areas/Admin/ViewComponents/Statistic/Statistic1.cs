using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace PresentationLayer.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.toplamBlogSayisi = blogManager.GetList().Count();
            ViewBag.mesajSayisi =context.Contacts.Count();
            ViewBag.yorumSayisi = context.Comments.Count();
            return View();
        }
    }
}
