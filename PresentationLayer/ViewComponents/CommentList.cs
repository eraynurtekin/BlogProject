using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using System.Collections.Generic;

namespace PresentationLayer.ViewComponents
{
    public class CommentList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var comments = new List<UserComment>
            {
                new UserComment
                {
                    ID = 1,
                    UserName = "Eray"
                },
                new UserComment
                {
                    ID=2,
                    UserName = "Nurtekin"
                }
            };
            return View(comments);
        }

    }
}
