using Dal;
using Dal.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bal
{
    public class InvoiceServices : IInvoiceServices
    {
        private readonly CarContext _DbContext;
        private readonly UserManager<Users> userManager;
        private readonly RoleManager<IdentityRole<int>> roleManager;

        public InvoiceServices(CarContext DbContext, UserManager<Users> userManager,
                                RoleManager<IdentityRole<int>> roleManager
                                )
        {
            _DbContext = DbContext;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public void getDetailsForInvoice(int userId,int garageId,int carserviceId)
        {
            UsersGarageCarServiceCustomModel data = new UsersGarageCarServiceCustomModel();
            data.Users = _DbContext.Users.Where(x => x.Id == userId).FirstOrDefault();
            data.Garage = _DbContext.Garage.Where(x => x.GarageId == garageId).FirstOrDefault();
            data.CarService = _DbContext.CarService.Where(x => x.CarServiceId == carserviceId).FirstOrDefault();
            //return View(data);
        }
    }
}
