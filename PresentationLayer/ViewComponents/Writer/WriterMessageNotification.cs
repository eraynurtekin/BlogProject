using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        Message2Manager messageManager = new Message2Manager(new EfMessage2Repository());
        public IViewComponentResult Invoke()
        {

            int id = 1;
            var values = messageManager.GetInboxListByWriter(id);
            return View(values);
        }
    }
}
