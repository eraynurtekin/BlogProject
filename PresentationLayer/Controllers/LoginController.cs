using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserSignInViewModel userSignInViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(userSignInViewModel.username, userSignInViewModel.password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return RedirectToAction("Index","Login");
                }

            }
            return View();
            //[HttpPost]
            //public async Task<IActionResult> Index(Writer writer)
            //{
            //    Context context = new Context();

            //    var dataValue = context.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);

            //    if (dataValue != null)
            //    {
            //        var claims = new List<Claim>
            //        {
            //            new Claim(ClaimTypes.Name,writer.WriterMail)
            //        };
            //        var userIdentity = new ClaimsIdentity(claims, "a");
            //        ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            //        await HttpContext.SignInAsync(principal);

            //        return RedirectToAction("Index", "Dashboard");
            //    }
            //    else
            //    {
            //        return View();
            //    }

            //}
        }

    }
}
//Context context = new Context();

//var dataValue = context.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);

//if(dataValue != null)
//{
//    HttpContext.Session.SetString("username",writer.WriterMail);
//    return RedirectToAction("Index","Writer");
//}
//else
//{
//    return View();
//}