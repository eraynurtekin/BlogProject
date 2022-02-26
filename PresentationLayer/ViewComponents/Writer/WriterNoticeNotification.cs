using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.Writer
{
    public class WriterNoticeNotification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
