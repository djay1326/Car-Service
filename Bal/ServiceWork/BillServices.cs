using Dal;
using Dal.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bal
{
    public class BillServices : IBillServices
    {
        private readonly CarContext _DbContext;
        private readonly UserManager<Users> userManager;
        private readonly RoleManager<IdentityRole<int>> roleManager;

        public BillServices(CarContext DbContext, UserManager<Users> userManager,
                                RoleManager<IdentityRole<int>> roleManager
                                )
        {
            _DbContext = DbContext;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public void MakeBillOfWorkDone(List<ServiceWork> work, int loggedInUser)
        {
            foreach (ServiceWork serviceWork in work)
            {
                if (serviceWork.WorkId == 0)
                {
                    ServiceWork data = new ServiceWork();
                    data.Work = serviceWork.Work;
                    data.Price = serviceWork.Price;
                    _DbContext.ServiceWork.Add(data);
                }
                else
                {
                    _DbContext.ServiceWork.Update(serviceWork);

                }
            }
            _DbContext.SaveChanges();            
        }

        public void DeleteRowInBill(int rowId)
        {
            ServiceWork work = _DbContext.ServiceWork.Where(x => x.WorkId == rowId).FirstOrDefault();
            _DbContext.ServiceWork.Remove(work);
            _DbContext.SaveChanges();
        }
    }
}
