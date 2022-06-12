using ASPNETIdentityManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_TDPC13.DB;
using MVC_TDPC13.DB.Entities;
using MVC_TDPC13.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;


namespace MVC_TDPC13.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly Repository repository;

        private SignInManager<User> signInManager;
        private UserManager<User> userManager;
        private UserDBContext dbContext;
        private DBContext dBContext;
        public HomeController(SignInManager<User> signInManager,
            UserManager<User> userManager,
            UserDBContext dbContext,
            DBContext dBContext,
        Repository repository)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.dbContext = dbContext;
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PrenotazioniUser()
        {
            List<Prenotazione> prenotazione = this.repository.GetPersonWithFilter(User.Identity.Name);
            List<PrenotazioneModel> model = new List<PrenotazioneModel>();
            foreach (Prenotazione p in prenotazione)
                model.Add(new PrenotazioneModel()
                {
                    Week = p.Week,
                    User = p.User,
                    Suite = p.Suite
                });
            return View(model);
        }





        [Authorize]
        public IActionResult Prenotazione()
        {
            List<Suite> suite = this.repository.GetSuites();
            List<SuiteModel> model = new List<SuiteModel>();

            foreach (Suite p in suite)
                model.Add(new SuiteModel()
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Disponibilita = p.Disponibilita
                });

            return View(model);

        }

        public IActionResult AdminPage()
        {
            List<Prenotazione> prenotazione = this.repository.GetPrenotazioni();
            List<PrenotazioneModel> model = new List<PrenotazioneModel>();
            foreach (Prenotazione p in prenotazione)
                model.Add(new PrenotazioneModel()
                {
                    Week = p.Week,
                    User = p.User,
                    Suite = p.Suite
                });
            return View(model);
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

