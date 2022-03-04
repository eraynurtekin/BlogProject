using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PresentationLayer.Areas.Admin.Models;
using System.Collections.Generic;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }

        public static List<WriterClass> writers = new List<WriterClass>
        {
            new WriterClass
            {
                id =1,
                name ="Ayşe"
            },
            new WriterClass
            {
                id =2,
                name ="Ahmet"
            },new WriterClass
            {
                id =3,
                name ="Ali"
            }
        };
    }
}
