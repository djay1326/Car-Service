using Bal;
using Dal;
using Dal.Models;
using Dal.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Controllers
{

    public class AccountController : Controller
    {
        private readonly CarContext _DbContext;
        private readonly UserManager<Users> userManager;
        private readonly SignInManager<Users> signInManager;
        private readonly RoleManager<IdentityRole<int>> roleManager;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IUsersAccountServices _userAccountServices;
        public AccountController(CarContext DbContext, UserManager<Users> _userManager,
                                SignInManager<Users> _signInManager, RoleManager<IdentityRole<int>> _roleManager,
                                IWebHostEnvironment _webHostEnvironment, IUsersAccountServices userAccountServiecs,
                                IUsersAccountServices usersAccountServices )
        {
            _DbContext = DbContext;
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
            webHostEnvironment = _webHostEnvironment;
            _userAccountServices = usersAccountServices;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Redirection()
        {
            return View();
        }


        [BindProperty]
        public string inlineRadioOptions { get; set; } // here "inlineRadioOptions" refers to radio btns name = "inlineRadioOptions"
        public IUsersAccountServices UsersAccountServices { get; }

        [HttpPost]
        public IActionResult Redirection(string value)
        {
            if (inlineRadioOptions == "1")
            {
                return RedirectToAction("MechanicRegister");
            }
            if (inlineRadioOptions == "2")
            {
                return RedirectToAction("CustomerRegister");
            }
            return View();
        }

        public IActionResult MechanicRegister()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MechanicRegister(RegisterModel model)
        {
            ModelState.Remove("AddressLine1");
            ModelState.Remove("AddressLine2");
            ModelState.Remove("Postalcode");
            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                // Logic to store selected Image in folder
                if (model.CoverPhoto != null)
                {
                    string folder = "Profile/cover/";
                    folder += Guid.NewGuid().ToString() + " " + model.CoverPhoto.FileName; // Guid will generate new values so that if we select 2 same images they will have different names.

                    model.CoverUrl = "/" + folder;

                    string serverFolder = Path.Combine(webHostEnvironment.WebRootPath, folder); // Here we have actual folder path of above "folder"
                    await model.CoverPhoto.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }

                var user = _userAccountServices.CreateNewAccount(model);
                var result = await userManager.CreateAsync(user, model.Password);

                //var result = await _userAccountServiecs.CreateNewAccount1(model);
                //user.SecurityStamp = "KUAO3APWUYQHADD2QOZ7YNXAUIYNRZMB";               

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Mechanic").Wait();
                    if (User.IsInRole("Admin"))
                    {
                        return RedirectToAction("CustomersOfAdmin");
                    }
                    else
                    {
                        return RedirectToAction("Login");
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        public IActionResult CustomerRegister()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CustomerRegister(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Logic to store selected Image in folder
                if (model.CoverPhoto != null)
                {
                    string folder = "Profile/cover/";
                    folder += Guid.NewGuid().ToString() + " " + model.CoverPhoto.FileName; // Guid will generate new values so that if we select 2 same images they will have different names.

                    model.CoverUrl = "/" + folder;

                    string serverFolder = Path.Combine(webHostEnvironment.WebRootPath, folder); // Here we have actual folder path of above "folder"
                    await model.CoverPhoto.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }

                var user = _userAccountServices.CreateNewAccount(model);
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Customer").Wait();
                    if (User.IsInRole("Admin"))
                    {
                        return RedirectToAction("CustomersOfAdmin");
                    }
                    else
                    {
                        return RedirectToAction("Login");
                    }
                    
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                //var user = await userManager.FindByEmailAsync(model.Email);
                var user = await _userAccountServices.LoginToYourAccount(model);
                if (user != null && !user.EmailConfirmed && (await userManager.CheckPasswordAsync(user, model.Password)))
                {
                    ModelState.AddModelError(string.Empty, "Email not confirmed yet!");
                    return View(model);
                }

                var result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    var userPrincipal = await signInManager.CreateUserPrincipalAsync(user);
                    if (userPrincipal.IsInRole("Mechanic"))
                    {
                        return RedirectToAction("MechanicDashboard", "Dashboards");
                    }
                    else if (userPrincipal.IsInRole("Customer"))
                    {
                        return RedirectToAction("CustomerDashboard", "Dashboards");
                    }
                    else if (userPrincipal.IsInRole("Admin"))
                    {
                        return RedirectToAction("AdminDashboard", "Dashboards");
                    }
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Credentials");
            }
            return View(model);
        }

        public IActionResult smallDisplay()
        {
            return View();
        }


        public async Task<IActionResult> logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        [Authorize]
        public IActionResult CustomersOfAdmin()
        {
            int userId = int.Parse(userManager.GetUserId(User));
            List<Users> details = _userAccountServices.CustomersOfAdmin(userId);
            return View(details);
        }

        [Authorize]
        [HttpPost]
        public IActionResult CustomersOfAdmin(int? userroleids)
        {
            if(userroleids == 100)
            {
                int userId = int.Parse(userManager.GetUserId(User));
                var allUsers = _userAccountServices.CustomersOfAdmin(userId);
                ViewBag.selectedUserRole = userroleids;
                return View(allUsers);
            }
            var selectedUsers = (from s in _DbContext.Users
                     join t in _DbContext.UserRoles
                     on s.Id equals t.UserId
                     where t.RoleId == userroleids
                     select s).ToList();
            ViewBag.selectedUserRole = userroleids;
            return View(selectedUsers);
        }

        [Authorize]
        public IActionResult UpdateCustomersDetailsModal(int id)
        {
            var info = _DbContext.Users.Where(x => x.Id == id).FirstOrDefault();
            ViewBag.id = id;
            return View(info);
        }

        [Authorize]
        public bool UpdateCustomersDetails([FromBody] Users model)
        {
            _userAccountServices.UpdateCustomersDetails(model);
            return true;
        }

        [Authorize]
        public bool DeleteUserAccount(int id)
        {
            _userAccountServices.DeleteUserAccount(id);
            return true;
        }

        [Authorize]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [Authorize,HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(User);
                if(user == null)
                {
                    return RedirectToAction("smallDisplay");
                }

                var result = await userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if (result.Succeeded)
                {
                    ViewBag.IsSuccess = true;
                    ModelState.Clear();
                    await signInManager.RefreshSignInAsync(user);
                    return View();
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
    }
}
