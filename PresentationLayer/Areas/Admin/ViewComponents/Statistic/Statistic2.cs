using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace PresentationLayer.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2 : ViewComponent
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.lastBlogName = c.Blogs.OrderByDescending(x=>x.BlogID).Select(x=>x.BlogTitle).Take(1).FirstOrDefault();

            var values = blogManager.ListWithWriter().OrderByDescending(x=>x.BlogID).Select(x => x.Writer.WriterName).Take(1).FirstOrDefault();
            ViewBag.Writer = values;
            return View();
        }
    }
}
