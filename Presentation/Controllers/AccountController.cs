//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity;
 
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;


namespace Presentation.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        //use UseManager her create objet from it 

        public AccountController(UserManager<ApplicationUser> user,
           SignInManager<ApplicationUser> signInManager)
        {
            _userManager = user;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        } 
        public async Task< IActionResult> SaveRegister(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = registerViewModel.Username;
                user.PasswordHash = registerViewModel.Password;
                user.Address = registerViewModel.Address;
                IdentityResult result = await _userManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Departments");
                } 

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("",error.Description);
                }

                return View("Register", registerViewModel);

            }
            else
            {
                return View("Register", registerViewModel);
            }
        }
    }
}
