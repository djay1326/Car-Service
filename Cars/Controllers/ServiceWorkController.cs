using Bal;
using Dal;
using Dal.CustomModels;
using Dal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Controllers
{
    [Authorize]
    public class ServiceWorkController : Controller
    {
        private readonly CarContext _DbContext;
        private readonly UserManager<Users> userManager;
        private readonly SignInManager<Users> signInManager;
        private readonly RoleManager<IdentityRole<int>> roleManager;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IBillServices _billServices;
        public ServiceWorkController(CarContext DbContext, UserManager<Users> userManager,
                                SignInManager<Users> signInManager, RoleManager<IdentityRole<int>> roleManager,
                                IWebHostEnvironment webHostEnvironment, IBillServices billServices)
        {
            _DbContext = DbContext;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.webHostEnvironment = webHostEnvironment;
            _billServices = billServices;
        }
        public IActionResult AddServiceWork(int id)
        {          
            
            ViewBag.id = id;
            CarAppointment details = _DbContext.CarAppointment.Where(x => x.Id == id).FirstOrDefault();
            ViewBag.Manufacturer = details.CarModel;
            ViewBag.Name = details.CarName;
            ViewBag.Number = details.CarNumber;
            ViewBag.UserId = details.UserId;
            ViewBag.GarageId = details.GarageId;
            var x = _DbContext.InvoiceInfo.Where(x => x.CarAppointmentId == id).FirstOrDefault();
            if(x != null)
            {
                 ViewBag.CarAppointmentIdInvoice = x.InvoiceId;
                 ViewBag.CarAppointmentIdInInvoice = x.CarAppointmentId;
            }
            if (x == null)
            {
                ViewBag.CarAppointmentIdInvoice = 0;
                ViewBag.CarAppointmentIdInInvoice = 0;
            }
            UsersAndServiceWork allInfo = new UsersAndServiceWork();
            allInfo.ServiceWork = _DbContext.ServiceWork.Where(x => x.CarAppointmentId == id).ToList();
            allInfo.Users = (from s in _DbContext.CarAppointment
                             join t in _DbContext.Users
                             on s.UserId equals t.Id
                             where s.Id == id
                             select t).FirstOrDefault();
            //List<ServiceWork> allValues = _DbContext.ServiceWork.Where(x => x.CarAppointmentId == id).ToList();
            return View(allInfo);
        }

        public JsonResult PostMethodOfAddServiceWork([FromBody] List<ServiceWork> services)
        {
            foreach (ServiceWork work in services)
            {
                InvoiceInfo info = new InvoiceInfo();
                if (work.WorkId == 0)
                {
                    ServiceWork values = new ServiceWork();
                    values.CarAppointmentId = work.CarAppointmentId;
                    values.Work = work.Work;
                    values.Price = work.Price;

                    _DbContext.ServiceWork.Add(values);
                }
                else
                {
                    _DbContext.ServiceWork.Update(work);

                }
            }
            int details = _DbContext.SaveChanges();
            
            return Json(details);
        }

        public bool PostMethodOfRedirectionToInvoicePage([FromBody] InvoiceInfo details)
        {
            if(details.InvoiceId != 0)
            {                
                InvoiceInfo values = _DbContext.InvoiceInfo.Where(x => x.InvoiceId == details.InvoiceId).FirstOrDefault();
                values.Price = details.Price;
                values.TotalPrice = details.TotalPrice;
                _DbContext.InvoiceInfo.Update(values);
            }
            else
            {
                details.CreatedDate = DateTime.UtcNow;
                _DbContext.InvoiceInfo.Add(details);
            }
            _DbContext.SaveChanges();
            return true;
        }

        public string deleteTab(int i)
        {
            ServiceWork data = _DbContext.ServiceWork.Where(x => x.WorkId == i).FirstOrDefault();
            _DbContext.ServiceWork.Remove(data);
            _DbContext.SaveChanges();
            return "true";
        }

        public IActionResult InvoicePage(int id)
        {
            ViewBag.id = id;
            InvoiceInfo val = _DbContext.InvoiceInfo.Where(x => x.CarAppointmentId == id).FirstOrDefault();
            ViewBag.CarAppointmentIdInvoice = val.InvoiceId;
            List<ServiceWork> values = _DbContext.ServiceWork.Where(x => x.CarAppointmentId == id).ToList();
            ViewBag.Data = values;

            var information = _DbContext.InvoiceInfo.Where(y => y.CarAppointmentId == id).FirstOrDefault();
            ViewBag.InvoiceId = information.InvoiceId;
            ViewBag.CreatedDate = information.CreatedDate;
            ViewBag.UserId = information.UserId;
            ViewBag.Name = information.Name;
            ViewBag.Address = information.Address;
            ViewBag.City = information.City;
            ViewBag.PostalCode = information.PostalCode;
            ViewBag.State = information.State;
            ViewBag.Mobile = information.Mobile;
            ViewBag.Price = information.Price;
            ViewBag.Tax = information.Tax;
            ViewBag.TotalPrice = information.TotalPrice;

            var GarageInfo = (from s in _DbContext.InvoiceInfo
                              join t in _DbContext.Garage
                              on s.GarageId equals t.GarageId
                              where s.CarAppointmentId == id && s.GarageId == t.GarageId
                              select t).FirstOrDefault();
            ViewBag.GarageName = GarageInfo.GarageName;
            ViewBag.Add1 = GarageInfo.AddressLine1;
            ViewBag.Add2 = GarageInfo.AddressLine2;
            ViewBag.GarageCity = GarageInfo.City;
            ViewBag.GaragePostal = GarageInfo.PostalCode;
            ViewBag.GarageState = GarageInfo.State;

            CarService paymentStatus = _DbContext.CarService.Where(x => x.CarAppointmentId == id).FirstOrDefault();
            ViewBag.payment =  paymentStatus.PaymentStatus;

            return View(values);
        }


        public bool DisplayInvoicePrices([FromBody] InvoiceInfo details)
        {
            
                InvoiceInfo values = _DbContext.InvoiceInfo.Where(x => x.InvoiceId == details.InvoiceId).FirstOrDefault();
                values.Price = details.Price;
                values.TotalPrice = details.TotalPrice;
                _DbContext.InvoiceInfo.Update(values);
            
            _DbContext.SaveChanges();
            return true;
        }
    }
}
