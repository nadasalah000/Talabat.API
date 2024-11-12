using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Talabat.API.DTOs;
using Talabat.Core.Entites.identity;

namespace AdminDashBoard.Controllers
{
    public class AdminController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public AdminController(SignInManager<AppUser> signInManager,UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if(user == null)
            {
                ModelState.AddModelError("Email", "InvalidEmail");
                return RedirectToAction(nameof(Login));
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if(!result.Succeeded || !await _userManager.IsInRoleAsync(user,"Admin"))
            {
                ModelState.AddModelError(string.Empty, "You are No Authorized");
                return RedirectToAction(nameof (Login));
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
        }
    }
}
