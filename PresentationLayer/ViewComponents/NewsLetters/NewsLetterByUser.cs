using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.NewsLetters
{
    public class NewsLetterByUser : ViewComponent
    {
        NewsLetterManager newsLetterManager = new NewsLetterManager(new EfNewsLetterRepository());

        public IViewComponentResult Invoke(NewsLetter newsLetter)
        {

            newsLetter.MailStatus = true;
            newsLetterManager.NewsLetterAdd(newsLetter);
            return View();
            
        }

    }
}
