using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Xml.Linq;

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

            //hava durumu api ekleme:
            string api = "4e56f75d65dbdf2f9029db6bcee56b39";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + api;

            XDocument document = XDocument.Load(connection);
            ViewBag.weather = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            return View();
        }
    }
}
