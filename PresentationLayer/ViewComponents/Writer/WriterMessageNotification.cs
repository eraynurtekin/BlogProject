using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
