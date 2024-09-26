using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Presentation.Filters;
using System.Security.Claims;

namespace Presentation.Controllers
{
   // [HandleException]
    public class ExceptionController : Controller
    {
       // [HandleException]
        public IActionResult Index()
        {
            throw new Exception("error from Exception COntroller");
        }
       // [HandleException]
        public IActionResult Index2()
        {
            throw new Exception("error from Exception COntroller");

        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }
            [HttpPost]
        public async Task <IActionResult> Loginx(string username ,string password)
        {
            if(username =="asd" &&password =="123")
            {
                Claim userclaim = new Claim(ClaimTypes.Email,username);
                Claim passclaim = new Claim(ClaimTypes.Role,"Admin");

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                claimsIdentity.AddClaim(userclaim);
                claimsIdentity.AddClaim(passclaim); 
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(); 
                claimsPrincipal.AddIdentity(claimsIdentity);
               await HttpContext.SignInAsync(claimsPrincipal);
                return RedirectToAction("Index", "Home");
            }
            //ModelState.AddModelError("errorr" ,"Invalid user name ") 
            ViewData["error"] = "invalid username or password";
            return View();
        }









    }
}
