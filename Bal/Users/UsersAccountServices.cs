using Dal;
using Dal.Models;
using Dal.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bal
{
    public class UsersAccountServices : IUsersAccountServices
    {
        private readonly CarContext _DbContext;
        private readonly UserManager<Users> userManager;
        private readonly SignInManager<Users> signInManager;
        private readonly RoleManager<IdentityRole<int>> roleManager;
        private readonly IActionContextAccessor _actionContextAccessor; //For ModelState. Also added in Startup.cs 
        public UsersAccountServices(CarContext DbContext, UserManager<Users> userManager,
                                RoleManager<IdentityRole<int>> roleManager,
                                IActionContextAccessor actionContextAccessor
                                )
        {
            _DbContext = DbContext;
            this.userManager = userManager;
            this.roleManager = roleManager;
            _actionContextAccessor = actionContextAccessor;
        }

        public Users CreateNewAccount(RegisterModel model)
        {
            var userInfo = new Users
            {
                UserName = model.Email,
                Email = model.Email,
                Name = model.FirstName + " " + model.LastName,
                PhoneNumber = model.MobileNo,
                CreatedDate = DateTime.UtcNow,
                City = model.City,
                State = model.State,
                AddressLine1 = model.AddressLine1,
                AddressLine2 = model.AddressLine2,
                PostalCode = model.Postalcode,
                EmailConfirmed = true,
                CoverImageUrl = model.CoverUrl
            };
            //var result = await userManager.CreateAsync(user, model.Password);
            //RegisterModel model1 = result;
            return userInfo;
        }
        //public async Task<IdentityResult> CreateNewAccount1(RegisterModel model)
        //{
        //    var user = CreateNewAccount(model);
        //    var result = await userManager.CreateAsync(user, model.Password);
        //    //RegisterModel model1 = result;
        //    return result;
        //}

        public async Task<Users> LoginToYourAccount(LoginViewModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            return user;
            
        }
        public Users GetProfileDetails(int loggedUserId)
        {
            Users data = _DbContext.Users.Where(x => x.Id == loggedUserId).FirstOrDefault();
            return data;
        }

        public void ProfileUpdate(Users data, int loggedInUser)
        {
            Users user = _DbContext.Users.Where(x => x.Id == loggedInUser).FirstOrDefault();
            user.AddressLine1 = data.AddressLine1;
            user.AddressLine2 = data.AddressLine2;
            user.PostalCode = data.PostalCode;
            user.City = data.City;
            user.State = data.State;
            user.PhoneNumber = data.PhoneNumber;
            _DbContext.Users.Update(user);
            _DbContext.SaveChanges();
        }

        public List<Users> CustomersOfAdmin(int userId)
        {
            var details = _DbContext.Users.Where(x => !(x.Id == userId)).ToList();
            return details;
        }

        public void UpdateCustomersDetails([FromBody] Users model)
        {
            Users users = _DbContext.Users.Where(x => x.Id == model.Id).FirstOrDefault();
            users.UserName = model.UserName;
            users.NormalizedEmail = model.NormalizedEmail;
            users.NormalizedUserName = model.NormalizedUserName;
            users.Name = model.Name;
            users.Email = model.Email;
            users.PhoneNumber = model.PhoneNumber;
            users.AddressLine1 = model.AddressLine1;
            users.AddressLine2 = model.AddressLine2;
            users.City = model.City;
            users.State = model.State;
            users.PostalCode = model.PostalCode;

            _DbContext.Users.Update(users);
            _DbContext.SaveChanges();
        }

        public void DeleteUserAccount(int id)
        {
            Users user = _DbContext.Users.Where(x => x.Id == id).FirstOrDefault();
            _DbContext.Users.Remove(user);
            _DbContext.SaveChanges();
        }
    }
}
