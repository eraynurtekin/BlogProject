using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace PresentationLayer.ViewComponents.Writer
{
    public class WriterNoticeNotification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            NotificationManager notificationManager = new NotificationManager(new EfNotificationRepository());

            var values = notificationManager.GetList().Where(x=>x.NotificationStatus == true).
                OrderByDescending(x=>x.NotificationDate).Take(3).ToList();

            //var lastValues = values.Where(x => x.NotificationStatus == true);
            

            return View(values);

        }
    }
}
