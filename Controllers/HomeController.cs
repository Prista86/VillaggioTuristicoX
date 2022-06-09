using ASPNETIdentityManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_TDPC13.DB;
using MVC_TDPC13.DB.Entities;
using MVC_TDPC13.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MVC_TDPC13.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;

        private SignInManager<User> signInManager;
        private UserManager<User> userManager;
        private UserDBContext dbContext;
        public HomeController(SignInManager<User> signInManager,
            UserManager<User> userManager,
            UserDBContext dbContext)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Prenotazione()
        {
            return View();
        }

        public IActionResult AdminPage()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }


        public async Task<IActionResult> Register([FromServices] UserManager<User> userManager, UsersAndRolesViewModel usersViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User user = await userManager.FindByEmailAsync(usersViewModel.Email);
                    if (user == null)
                    {
                        user = new User
                        {
                            UserName = usersViewModel.UserName,
                            Email = usersViewModel.Email,
                            FirstName = usersViewModel.FirstName,
                            LastName = usersViewModel.LastName,
                            PhoneNumber = usersViewModel.PhoneNumber
                        };
                        IdentityResult result = await userManager.CreateAsync(user, usersViewModel.Password);
                        if (result.Succeeded)
                            return Json("OK");

                        string errors = string.Empty;
                        foreach (IdentityError error in result.Errors)
                            errors += error.Code + ": " + error.Description + "\n";
                        return Json(errors);
                    }
                    else
                        return Json("Email is already taken");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
            }
            return Json("Invalid request");
        }








        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            try
            {
                User user = await userManager.FindByNameAsync(loginModel.UserName);
                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password, false, lockoutOnFailure: true);
                    if (result.Succeeded)
                    {

                    }
                }
            }
            catch (Exception ex)
            {

            }
            return Redirect("Index");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            try
            {
                if (signInManager.IsSignedIn(User))
                {
                    await signInManager.SignOutAsync();
                }
            }
            catch (Exception ex)
            {
            }
            return Redirect("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

