﻿using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace PresentationLayer.ViewComponents.Writer
{
    
    public class WriterAboutOnDashboard : ViewComponent
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());

        Context c = new Context();

        public IViewComponentResult Invoke()
        {
            var userMail = User.Identity.Name;
            
            var writerID = c.Writers.Where(x=>x.WriterMail == userMail).Select(y=>y.WriterID).FirstOrDefault();

            var values = writerManager.GetWriterById(writerID);
            return View(values);
        }

    }
}
