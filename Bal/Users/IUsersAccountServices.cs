using Dal.Models;
using Dal.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bal
{
    public interface IUsersAccountServices
    {
        Users CreateNewAccount(RegisterModel model);

        //Task<IdentityResult> CreateNewAccount1(RegisterModel model);
        Task<Users> LoginToYourAccount(LoginViewModel model);
        Users GetProfileDetails(int loggedUserId);
        void ProfileUpdate(Users data, int loggedInUser);

        List<Users> CustomersOfAdmin(int userId);

        void UpdateCustomersDetails([FromBody] Users model);
        void DeleteUserAccount(int id);
    }
}
