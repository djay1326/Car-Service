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
    public class CarAppointmentController : Controller
    {
        private readonly CarContext _DbContext;
        private readonly UserManager<Users> userManager;
        private readonly SignInManager<Users> signInManager;
        private readonly RoleManager<IdentityRole<int>> roleManager;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ICarAppointmentServices _carAppointmentServices;
        public CarAppointmentController(CarContext DbContext, UserManager<Users> userManager,
                                SignInManager<Users> signInManager, RoleManager<IdentityRole<int>> roleManager,
                                IWebHostEnvironment webHostEnvironment, ICarAppointmentServices carAppointmentServices)
        {
            _DbContext = DbContext;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.webHostEnvironment = webHostEnvironment;
            _carAppointmentServices = carAppointmentServices;
        }
        public IActionResult CustomerMakesAppointment(int id)
        {
            Garage model = _DbContext.Garage.Where(x => x.GarageId == id).FirstOrDefault();
            ViewBag.GarageId = id;
            List<CarManufacturers> carManufacturers = _DbContext.CarManufacturers.ToList();
            ViewBag.cars = carManufacturers;
            return View(model);
        }

        [HttpPost]
        public bool PostMethodofCustomerMakesAppointment([FromBody] Garage model)
        {
            int id = int.Parse(userManager.GetUserId(User));
            _carAppointmentServices.PostMethodofCustomerMakesAppointment(model, id);
            return true;
        }

        public IActionResult ListAllAppointmentsOfCustomer()
        {
            //List<CarAppointment> myAllAppointments = _DbContext.CarAppointment.ToList();
            int userId = int.Parse(userManager.GetUserId(User));
            bool isAdmin = User.IsInRole("Admin");
            var myAppointments = _carAppointmentServices.ListAllAppointmentsOfCustomer(userId, isAdmin);
            return View(myAppointments);
        }

        

        public IActionResult ListAppointmentRequestsforMechanic()
        {
            int userId = int.Parse(userManager.GetUserId(User));
            var myAppointments = _carAppointmentServices.ListAppointmentRequestsforMechanic(userId);
            return View(myAppointments);
        }

        public IActionResult GetAppointmentDetailsForUpdating(int id)
        {
            CarAppointmentAndGarageCustomModel details = new CarAppointmentAndGarageCustomModel();
            details.CarAppointment = _DbContext.CarAppointment.Where(x => x.Id == id).FirstOrDefault();
            details.Garage = _DbContext.Garage.Where(y => y.GarageId == details.CarAppointment.GarageId).FirstOrDefault();
            ViewBag.approxCost = details.CarAppointment.ApproxCost;
            ViewBag.GarageId = details.CarAppointment.GarageId;
            List<CarManufacturers> carManufacturers = (from s in _DbContext.CarManufacturers
                                                       select s).ToList();

            ViewBag.cars = carManufacturers;
            ViewBag.Id = id;
            return View(details);

        }

        public string UpdateBookedAppointment([FromBody] CarAppointment model)
        {
            _carAppointmentServices.UpdateBookedAppointment(model);
            return "true";
        }

        public bool DeleteAppointment(int id)
        {
            _carAppointmentServices.DeleteAppointment(id);
            return true;
        }

        public bool UpdatePaymentStatus(int id)
        {
            _carAppointmentServices.UpdatePaymentStatus(id);
            return true;
        }

        public IActionResult UpdateAppointmentStatus(int id, int status,int? dashboardId)
        {
            _carAppointmentServices.UpdateAppointmentStatus(id, status);
            if ((status == 2 && dashboardId != 100 )|| (status == 3 && dashboardId != 100))
            {
                return RedirectToAction("ListAppointmentRequestsforMechanic", "CarAppointment");
            }
            else if ((status == 2 && dashboardId == 100) || (status == 3 && dashboardId == 100))
            {
                return RedirectToAction("MechanicDashboard", "Dashboards");
            }
            else
            {
                return RedirectToAction("ListApprovedAppointments", "CarAppointment");
            }
        }

        public IActionResult ListApprovedAppointments()
        {
            int userId = int.Parse(userManager.GetUserId(User));
            var approvedAppointments = _carAppointmentServices.ListApprovedAppointments(userId);
            return View(approvedAppointments);
        }

        public IActionResult AdminViewAllAppointments()
        {
            int userId = int.Parse(userManager.GetUserId(User));
            bool isAdmin = User.IsInRole("Admin");
            var allAppointments = _carAppointmentServices.ListAllAppointmentsOfCustomer(userId, isAdmin);
            return View(allAppointments);
        }

        [HttpPost]
        public IActionResult ListApprovedAppointments(DateTime startdate, int? paymentstatusids, int? statusids, string anytext)
        {
            int userId = int.Parse(userManager.GetUserId(User));
            DateTime xy = DateTime.Parse("01-01-0001 12:00:00 AM");
            DateTime uy = DateTime.Parse("01-01-9999 12:00:00 AM");
            var approvedAppointments = _carAppointmentServices.ListApprovedAppointments(userId);
            if (startdate == xy && paymentstatusids == null && anytext == null)
            {
                if (statusids != 100)
                {
                    var result1 = approvedAppointments.Where(x => x.ServiceStatus == statusids).ToList();
                    ViewBag.status = statusids;
                    return View(result1);
                }
                else
                {
                    ViewBag.status = statusids;
                    return View(approvedAppointments);
                }

            }
            else if (paymentstatusids == null && anytext == null && statusids == null)
            {
                var result2 = approvedAppointments.Where(x => x.AppointmentAcceptDate.Value.ToShortDateString() == startdate.ToShortDateString()).ToList();
                ViewBag.startdate = startdate.ToString("yyyy-MM-dd");
                return View(result2);
            }
            else if (paymentstatusids == null && anytext == null)
            {
                var result3 = approvedAppointments.Where(x => (x.ServiceStatus == statusids) && (x.AppointmentAcceptDate.Value.ToShortDateString() == startdate.ToShortDateString())).ToList();
                ViewBag.startdate = startdate.ToString("yyyy-MM-dd");
                ViewBag.status = statusids;
                return View(result3);
            }
            else if (startdate == xy && statusids == null && anytext == null)
            {
                if (paymentstatusids != 100)
                {
                    var result4 = approvedAppointments.Where(x => x.StatusOfPayment == paymentstatusids).ToList();
                    ViewBag.statusOfPayment = paymentstatusids;
                    return View(result4);
                }
                else
                {
                    ViewBag.statusOfPayment = paymentstatusids;
                    return View(approvedAppointments);
                }
            }
            else if (startdate == xy && anytext == null)
            {
                var result5 = approvedAppointments.Where(x => (x.StatusOfPayment == paymentstatusids) && (x.ServiceStatus == statusids)).ToList();
                ViewBag.statusOfPayment = paymentstatusids;
                ViewBag.status = statusids;
                return View(result5);
            }
            else if (statusids == null && anytext == null)
            {
                var result6 = approvedAppointments.Where(x => (x.StatusOfPayment == paymentstatusids) && (x.AppointmentAcceptDate.Value.ToShortDateString() == startdate.ToShortDateString())).ToList();
                ViewBag.startdate = startdate.ToString("yyyy-MM-dd");
                ViewBag.statusOfPayment = paymentstatusids;
                return View(result6);
            }
            else if (anytext == null)
            {
                var result6 = approvedAppointments.Where(x => (x.StatusOfPayment == paymentstatusids) && (x.ServiceStatus == statusids) &&
                                (x.AppointmentAcceptDate.Value.ToShortDateString() == startdate.ToShortDateString())).ToList();
                ViewBag.startdate = startdate.ToString("yyyy-MM-dd");
                ViewBag.statusOfPayment = paymentstatusids;
                ViewBag.status = statusids;
                return View(result6);
            }
            else if (paymentstatusids == 100 || statusids == 100)
            {
                return View(approvedAppointments);
            }
            else if (startdate == xy && paymentstatusids == null && statusids == null)
            {
                var result7 = approvedAppointments.Where(x => (x.NameOfUser.ToLower().Contains(anytext)) || (x.UserAddressLine1.ToLower().Contains(anytext))
                                    || (x.UserAddressLine2.ToLower().Contains(anytext)) || (x.UserCity.ToLower().Contains(anytext))
                                    || (x.UserState.ToLower().Contains(anytext)) || (x.UserPostalCode.ToLower().Contains(anytext)) || (x.UserEmail.ToLower().Contains(anytext))
                                    || (x.UserPhoneNo.ToLower().Contains(anytext))
                                    || (x.CarModel.ToLower().Contains(anytext)) || (x.CarName.ToLower().Contains(anytext)) || (x.CarNumber.ToLower().Contains(anytext))
                                    || (x.GarageName.ToLower().Contains(anytext)) || (x.AddressLine1.ToLower().Contains(anytext))
                                    || (x.AddressLine2.ToLower().Contains(anytext)) || (x.City.ToLower().Contains(anytext)) || (x.State.ToLower().Contains(anytext))
                                    || (x.PostalCode.ToLower().Contains(anytext))
                ).ToList();
                ViewBag.anytext = anytext;
                return View(result7);
            }
            else if (startdate == xy && statusids == null)
            {
                var result8 = approvedAppointments.Where(x => ((x.NameOfUser.ToLower().Contains(anytext)) || (x.UserAddressLine1.ToLower().Contains(anytext))
                                    || (x.UserAddressLine2.ToLower().Contains(anytext)) || (x.UserCity.ToLower().Contains(anytext))
                                    || (x.UserState.ToLower().Contains(anytext)) || (x.UserPostalCode.ToLower().Contains(anytext)) || (x.UserEmail.ToLower().Contains(anytext))
                                    || (x.UserPhoneNo.ToLower().Contains(anytext))
                                    || (x.CarModel.ToLower().Contains(anytext)) || (x.CarName.ToLower().Contains(anytext)) || (x.CarNumber.ToLower().Contains(anytext))
                                    || (x.GarageName.ToLower().Contains(anytext)) || (x.AddressLine1.ToLower().Contains(anytext))
                                    || (x.AddressLine2.ToLower().Contains(anytext)) || (x.City.ToLower().Contains(anytext)) || (x.State.ToLower().Contains(anytext))
                                    || (x.PostalCode.ToLower().Contains(anytext))) && (x.StatusOfPayment == paymentstatusids)
                ).ToList();
                ViewBag.anytext = anytext;
                ViewBag.statusOfPayment = paymentstatusids;
                return View(result8);
            }
            else if (startdate == xy)
            {
                var result9 = approvedAppointments.Where(x => ((x.NameOfUser.ToLower().Contains(anytext)) || (x.UserAddressLine1.ToLower().Contains(anytext))
                                    || (x.UserAddressLine2.ToLower().Contains(anytext)) || (x.UserCity.ToLower().Contains(anytext))
                                    || (x.UserState.ToLower().Contains(anytext)) || (x.UserPostalCode.ToLower().Contains(anytext)) || (x.UserEmail.ToLower().Contains(anytext))
                                    || (x.UserPhoneNo.ToLower().Contains(anytext))
                                    || (x.CarModel.ToLower().Contains(anytext)) || (x.CarName.ToLower().Contains(anytext)) || (x.CarNumber.ToLower().Contains(anytext))
                                    || (x.GarageName.ToLower().Contains(anytext)) || (x.AddressLine1.ToLower().Contains(anytext))
                                    || (x.AddressLine2.ToLower().Contains(anytext)) || (x.City.ToLower().Contains(anytext)) || (x.State.ToLower().Contains(anytext))
                                    || (x.PostalCode.ToLower().Contains(anytext))) && (x.StatusOfPayment == paymentstatusids) && (x.ServiceStatus == statusids)
                ).ToList();
                ViewBag.anytext = anytext;
                ViewBag.statusOfPayment = paymentstatusids;
                ViewBag.status = statusids;
                return View(result9);
            }
            else if (paymentstatusids == null && statusids == null)
            {
                var result10 = approvedAppointments.Where(x => ((x.NameOfUser.ToLower().Contains(anytext)) || (x.UserAddressLine1.ToLower().Contains(anytext))
                                    || (x.UserAddressLine2.ToLower().Contains(anytext)) || (x.UserCity.ToLower().Contains(anytext))
                                    || (x.UserState.ToLower().Contains(anytext)) || (x.UserPostalCode.ToLower().Contains(anytext)) || (x.UserEmail.ToLower().Contains(anytext))
                                    || (x.UserPhoneNo.ToLower().Contains(anytext))
                                    || (x.CarModel.ToLower().Contains(anytext)) || (x.CarName.ToLower().Contains(anytext)) || (x.CarNumber.ToLower().Contains(anytext))
                                    || (x.GarageName.ToLower().Contains(anytext)) || (x.AddressLine1.ToLower().Contains(anytext))
                                    || (x.AddressLine2.ToLower().Contains(anytext)) || (x.City.ToLower().Contains(anytext)) || (x.State.ToLower().Contains(anytext))
                                    || (x.PostalCode.ToLower().Contains(anytext))) && (x.AppointmentAcceptDate.Value.ToShortDateString() == startdate.ToShortDateString())
                ).ToList();
                ViewBag.anytext = anytext;
                ViewBag.startdate = startdate.ToString("yyyy-MM-dd");
                return View(result10);
            }
            else
            {
                var resultFinal = approvedAppointments.Where(x => ((x.NameOfUser.ToLower().Contains(anytext)) || (x.UserAddressLine1.ToLower().Contains(anytext))
                                    || (x.UserAddressLine2.ToLower().Contains(anytext)) || (x.UserCity.ToLower().Contains(anytext))
                                    || (x.UserState.ToLower().Contains(anytext)) || (x.UserPostalCode.ToLower().Contains(anytext)) || (x.UserEmail.ToLower().Contains(anytext))
                                    || (x.UserPhoneNo.ToLower().Contains(anytext))
                                    || (x.CarModel.ToLower().Contains(anytext)) || (x.CarName.ToLower().Contains(anytext)) || (x.CarNumber.ToLower().Contains(anytext))
                                    || (x.GarageName.ToLower().Contains(anytext)) || (x.AddressLine1.ToLower().Contains(anytext))
                                    || (x.AddressLine2.ToLower().Contains(anytext)) || (x.City.ToLower().Contains(anytext)) || (x.State.ToLower().Contains(anytext))
                                    || (x.PostalCode.ToLower().Contains(anytext))) && (x.StatusOfPayment == paymentstatusids) && (x.ServiceStatus == statusids)
                                    && (x.AppointmentAcceptDate.Value.ToShortDateString() == startdate.ToShortDateString())
                ).ToList();
                ViewBag.startdate = startdate.ToString("yyyy-MM-dd");
                ViewBag.statusOfPayment = paymentstatusids;
                ViewBag.status = statusids;
                ViewBag.anytext = anytext;
                return View(resultFinal);
            }
            return View();
        }

        [HttpPost]
        public IActionResult AdminViewAllAppointments(int? paymentstatusids, int? statusids, string anytext)
        {
            int userId = int.Parse(userManager.GetUserId(User));
            bool isAdmin = User.IsInRole("Admin");
            var allAppointments = _carAppointmentServices.ListAllAppointmentsOfCustomer(userId, isAdmin);
            if(anytext == null && paymentstatusids == null)
            {
                if (statusids != 100)
                {
                    var result1 = allAppointments.Where(x => x.ServiceStatus == statusids).ToList();
                    ViewBag.status = statusids;
                    return View(result1);
                }
                else
                {
                    ViewBag.status = statusids;
                    return View(allAppointments);
                }
            }
            else if(anytext == null && statusids == null)
            {
                if (paymentstatusids != 100)
                {
                    var result2 = allAppointments.Where(x => x.StatusOfPayment == paymentstatusids).ToList();
                    ViewBag.statusOfPayment = paymentstatusids;
                    return View(result2);
                }
                else
                {
                    ViewBag.statusOfPayment = paymentstatusids;
                    return View(allAppointments);
                }
            }
            else if(anytext == null)
            {
                var result3 = allAppointments.Where(x => (x.StatusOfPayment == paymentstatusids) && (x.ServiceStatus == statusids)).ToList();
                ViewBag.statusOfPayment = paymentstatusids;
                ViewBag.status = statusids;
                return View(result3);
            }
            else if(paymentstatusids == null && statusids == null)
            {
                var result4 = allAppointments.Where(x => (x.NameOfUser.ToLower().Contains(anytext)) || (x.UserAddressLine1.ToLower().Contains(anytext))
                                    || (x.UserAddressLine2.ToLower().Contains(anytext)) || (x.UserCity.ToLower().Contains(anytext))
                                    || (x.UserState.ToLower().Contains(anytext)) || (x.UserPostalCode.ToLower().Contains(anytext)) || (x.UserEmail.ToLower().Contains(anytext))
                                    || (x.UserPhoneNo.ToLower().Contains(anytext))
                                    || (x.CarModel.ToLower().Contains(anytext)) || (x.CarName.ToLower().Contains(anytext)) || (x.CarNumber.ToLower().Contains(anytext))
                                    || (x.GarageName.ToLower().Contains(anytext)) || (x.AddressLine1.ToLower().Contains(anytext))
                                    || (x.AddressLine2.ToLower().Contains(anytext)) || (x.City.ToLower().Contains(anytext)) || (x.State.ToLower().Contains(anytext))
                                    || (x.PostalCode.ToLower().Contains(anytext))
                ).ToList();
                ViewBag.anytext = anytext;
                return View(result4);
            }
            else if(paymentstatusids == null)
            {
                var result5 = allAppointments.Where(x => ((x.NameOfUser.ToLower().Contains(anytext)) || (x.UserAddressLine1.ToLower().Contains(anytext))
                                    || (x.UserAddressLine2.ToLower().Contains(anytext)) || (x.UserCity.ToLower().Contains(anytext))
                                    || (x.UserState.ToLower().Contains(anytext)) || (x.UserPostalCode.ToLower().Contains(anytext)) || (x.UserEmail.ToLower().Contains(anytext))
                                    || (x.UserPhoneNo.ToLower().Contains(anytext))
                                    || (x.CarModel.ToLower().Contains(anytext)) || (x.CarName.ToLower().Contains(anytext)) || (x.CarNumber.ToLower().Contains(anytext))
                                    || (x.GarageName.ToLower().Contains(anytext)) || (x.AddressLine1.ToLower().Contains(anytext))
                                    || (x.AddressLine2.ToLower().Contains(anytext)) || (x.City.ToLower().Contains(anytext)) || (x.State.ToLower().Contains(anytext))
                                    || (x.PostalCode.ToLower().Contains(anytext))) && (x.StatusOfPayment == paymentstatusids)
                ).ToList();
                ViewBag.anytext = anytext;
                ViewBag.statusOfPayment = paymentstatusids;
                return View(result5);
            }
            else
            {
                var resultFinal = allAppointments.Where(x => ((x.NameOfUser.ToLower().Contains(anytext)) || (x.UserAddressLine1.ToLower().Contains(anytext))
                                    || (x.UserAddressLine2.ToLower().Contains(anytext)) || (x.UserCity.ToLower().Contains(anytext))
                                    || (x.UserState.ToLower().Contains(anytext)) || (x.UserPostalCode.ToLower().Contains(anytext)) || (x.UserEmail.ToLower().Contains(anytext))
                                    || (x.UserPhoneNo.ToLower().Contains(anytext))
                                    || (x.CarModel.ToLower().Contains(anytext)) || (x.CarName.ToLower().Contains(anytext)) || (x.CarNumber.ToLower().Contains(anytext))
                                    || (x.GarageName.ToLower().Contains(anytext)) || (x.AddressLine1.ToLower().Contains(anytext))
                                    || (x.AddressLine2.ToLower().Contains(anytext)) || (x.City.ToLower().Contains(anytext)) || (x.State.ToLower().Contains(anytext))
                                    || (x.PostalCode.ToLower().Contains(anytext))) && (x.StatusOfPayment == paymentstatusids) && (x.ServiceStatus == statusids)).ToList();
                ViewBag.statusOfPayment = paymentstatusids;
                ViewBag.status = statusids;
                ViewBag.anytext = anytext;
                return View(resultFinal);
            }
            return View();
        }
        public IActionResult AddServiceWork(int id)
        {
            return View();
        }

        public IActionResult CustomersServices()
        {
            int userId = int.Parse(userManager.GetUserId(User));
            var myAppointments = _carAppointmentServices.CustomersServices(userId);
            return View(myAppointments);
        }

        [HttpPost]
        public IActionResult CustomersServices(DateTime startdate, int? paymentstatusids, int? statusids, string anytext)
        {
            int userId = int.Parse(userManager.GetUserId(User));
            DateTime xy = DateTime.Parse("01-01-0001 12:00:00 AM");
            DateTime uy = DateTime.Parse("01-01-9999 12:00:00 AM");
            var myAppointments = _carAppointmentServices.CustomersServices(userId);
            if (startdate == xy && paymentstatusids == null && anytext == null)
            {
                if (statusids != 100)
                {
                    var result1 = myAppointments.Where(x => x.ServiceStatus == statusids).ToList();
                    ViewBag.status = statusids;
                    return View(result1);
                }
                else
                {
                    ViewBag.status = statusids;
                    return View(myAppointments);
                }

            }
            else if (paymentstatusids == null && anytext == null && statusids == null)
            {
                var result2 = myAppointments.Where(x => x.AppointmentAcceptDate.Value.ToShortDateString() == startdate.ToShortDateString()).ToList();
                ViewBag.startdate = startdate.ToString("yyyy-MM-dd");
                return View(result2);
            }
            else if (paymentstatusids == null && anytext == null)
            {
                var result3 = myAppointments.Where(x => (x.ServiceStatus == statusids) && (x.AppointmentAcceptDate.Value.ToShortDateString() == startdate.ToShortDateString())).ToList();
                ViewBag.startdate = startdate.ToString("yyyy-MM-dd");
                ViewBag.status = statusids;
                return View(result3);
            }
            else if (startdate == xy && statusids == null && anytext == null)
            {
                if (paymentstatusids != 100)
                {
                    var result4 = myAppointments.Where(x => x.StatusOfPayment == paymentstatusids).ToList();
                    ViewBag.statusOfPayment = paymentstatusids;
                    return View(result4);
                }
                else
                {
                    return View(myAppointments);
                }
            }
            else if (startdate == xy && anytext == null)
            {
                var result5 = myAppointments.Where(x => (x.StatusOfPayment == paymentstatusids) && (x.ServiceStatus == statusids)).ToList();
                ViewBag.statusOfPayment = paymentstatusids;
                ViewBag.status = statusids;
                return View(result5);
            }
            else if (statusids == null && anytext == null)
            {
                var result6 = myAppointments.Where(x => (x.StatusOfPayment == paymentstatusids) && (x.AppointmentAcceptDate.Value.ToShortDateString() == startdate.ToShortDateString())).ToList();
                ViewBag.startdate = startdate.ToString("yyyy-MM-dd");
                ViewBag.statusOfPayment = paymentstatusids;
                return View(result6);
            }
            else if (anytext == null)
            {
                var result6 = myAppointments.Where(x => (x.StatusOfPayment == paymentstatusids) && (x.ServiceStatus == statusids) &&
                                (x.AppointmentAcceptDate.Value.ToShortDateString() == startdate.ToShortDateString())).ToList();
                ViewBag.startdate = startdate.ToString("yyyy-MM-dd");
                ViewBag.statusOfPayment = paymentstatusids;
                ViewBag.status = statusids;
                return View(result6);
            }
            else if (paymentstatusids == 100 || statusids == 100)
            {
                return View(myAppointments);
            }
            else if (startdate == xy && paymentstatusids == null && statusids == null)
            {
                var result7 = myAppointments.Where(x => (x.NameOfUser.ToLower().Contains(anytext)) || (x.UserAddressLine1.ToLower().Contains(anytext))
                                    || (x.UserAddressLine2.ToLower().Contains(anytext)) || (x.UserCity.ToLower().Contains(anytext))
                                    || (x.UserState.ToLower().Contains(anytext)) || (x.UserPostalCode.ToLower().Contains(anytext)) || (x.UserEmail.ToLower().Contains(anytext))
                                    || (x.UserPhoneNo.ToLower().Contains(anytext))
                                    || (x.CarModel.ToLower().Contains(anytext)) || (x.CarName.ToLower().Contains(anytext)) || (x.CarNumber.ToLower().Contains(anytext))
                                    || (x.GarageName.ToLower().Contains(anytext)) || (x.AddressLine1.ToLower().Contains(anytext))
                                    || (x.AddressLine2.ToLower().Contains(anytext)) || (x.City.ToLower().Contains(anytext)) || (x.State.ToLower().Contains(anytext))
                                    || (x.PostalCode.ToLower().Contains(anytext))
                ).ToList();
                ViewBag.anytext = anytext;
                return View(result7);
            }
            else if (startdate == xy && statusids == null)
            {
                var result8 = myAppointments.Where(x => ((x.NameOfUser.ToLower().Contains(anytext)) || (x.UserAddressLine1.ToLower().Contains(anytext))
                                    || (x.UserAddressLine2.ToLower().Contains(anytext)) || (x.UserCity.ToLower().Contains(anytext))
                                    || (x.UserState.ToLower().Contains(anytext)) || (x.UserPostalCode.ToLower().Contains(anytext)) || (x.UserEmail.ToLower().Contains(anytext))
                                    || (x.UserPhoneNo.ToLower().Contains(anytext))
                                    || (x.CarModel.ToLower().Contains(anytext)) || (x.CarName.ToLower().Contains(anytext)) || (x.CarNumber.ToLower().Contains(anytext))
                                    || (x.GarageName.ToLower().Contains(anytext)) || (x.AddressLine1.ToLower().Contains(anytext))
                                    || (x.AddressLine2.ToLower().Contains(anytext)) || (x.City.ToLower().Contains(anytext)) || (x.State.ToLower().Contains(anytext))
                                    || (x.PostalCode.ToLower().Contains(anytext))) && (x.StatusOfPayment == paymentstatusids)
                ).ToList();
                ViewBag.anytext = anytext;
                ViewBag.statusOfPayment = paymentstatusids;
                return View(result8);
            }
            else if (startdate == xy)
            {
                var result9 = myAppointments.Where(x => ((x.NameOfUser.ToLower().Contains(anytext)) || (x.UserAddressLine1.ToLower().Contains(anytext))
                                    || (x.UserAddressLine2.ToLower().Contains(anytext)) || (x.UserCity.ToLower().Contains(anytext))
                                    || (x.UserState.ToLower().Contains(anytext)) || (x.UserPostalCode.ToLower().Contains(anytext)) || (x.UserEmail.ToLower().Contains(anytext))
                                    || (x.UserPhoneNo.ToLower().Contains(anytext))
                                    || (x.CarModel.ToLower().Contains(anytext)) || (x.CarName.ToLower().Contains(anytext)) || (x.CarNumber.ToLower().Contains(anytext))
                                    || (x.GarageName.ToLower().Contains(anytext)) || (x.AddressLine1.ToLower().Contains(anytext))
                                    || (x.AddressLine2.ToLower().Contains(anytext)) || (x.City.ToLower().Contains(anytext)) || (x.State.ToLower().Contains(anytext))
                                    || (x.PostalCode.ToLower().Contains(anytext))) && (x.StatusOfPayment == paymentstatusids) && (x.ServiceStatus == statusids)
                ).ToList();
                ViewBag.anytext = anytext;
                ViewBag.statusOfPayment = paymentstatusids;
                ViewBag.status = statusids;
                return View(result9);
            }
            else if (paymentstatusids == null && statusids == null)
            {
                var result10 = myAppointments.Where(x => ((x.NameOfUser.ToLower().Contains(anytext)) || (x.UserAddressLine1.ToLower().Contains(anytext))
                                    || (x.UserAddressLine2.ToLower().Contains(anytext)) || (x.UserCity.ToLower().Contains(anytext))
                                    || (x.UserState.ToLower().Contains(anytext)) || (x.UserPostalCode.ToLower().Contains(anytext)) || (x.UserEmail.ToLower().Contains(anytext))
                                    || (x.UserPhoneNo.ToLower().Contains(anytext))
                                    || (x.CarModel.ToLower().Contains(anytext)) || (x.CarName.ToLower().Contains(anytext)) || (x.CarNumber.ToLower().Contains(anytext))
                                    || (x.GarageName.ToLower().Contains(anytext)) || (x.AddressLine1.ToLower().Contains(anytext))
                                    || (x.AddressLine2.ToLower().Contains(anytext)) || (x.City.ToLower().Contains(anytext)) || (x.State.ToLower().Contains(anytext))
                                    || (x.PostalCode.ToLower().Contains(anytext))) && (x.AppointmentAcceptDate.Value.ToShortDateString() == startdate.ToShortDateString())
                ).ToList();
                ViewBag.anytext = anytext;
                ViewBag.startdate = startdate.ToString("yyyy-MM-dd");
                return View(result10);
            }
            else
            {
                var resultFinal = myAppointments.Where(x => ((x.NameOfUser.ToLower().Contains(anytext)) || (x.UserAddressLine1.ToLower().Contains(anytext))
                                    || (x.UserAddressLine2.ToLower().Contains(anytext)) || (x.UserCity.ToLower().Contains(anytext))
                                    || (x.UserState.ToLower().Contains(anytext)) || (x.UserPostalCode.ToLower().Contains(anytext)) || (x.UserEmail.ToLower().Contains(anytext))
                                    || (x.UserPhoneNo.ToLower().Contains(anytext))
                                    || (x.CarModel.ToLower().Contains(anytext)) || (x.CarName.ToLower().Contains(anytext)) || (x.CarNumber.ToLower().Contains(anytext))
                                    || (x.GarageName.ToLower().Contains(anytext)) || (x.AddressLine1.ToLower().Contains(anytext))
                                    || (x.AddressLine2.ToLower().Contains(anytext)) || (x.City.ToLower().Contains(anytext)) || (x.State.ToLower().Contains(anytext))
                                    || (x.PostalCode.ToLower().Contains(anytext))) && (x.StatusOfPayment == paymentstatusids) && (x.ServiceStatus == statusids)
                                    && (x.AppointmentAcceptDate.Value.ToShortDateString() == startdate.ToShortDateString())
                ).ToList();
                ViewBag.startdate = startdate.ToString("yyyy-MM-dd");
                ViewBag.anytext = anytext;
                return View(resultFinal);
            }
            return View();
        }

        public IActionResult ServiceHistory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ServiceHistory(string anytext)
        {
            int userId = int.Parse(userManager.GetUserId(User));
            bool isAdmin = User.IsInRole("Admin");
            var details = _carAppointmentServices.ServiceHistory(userId,isAdmin);
            var thoseGarages = details.Where(x => x.CarNumber.ToLower() == anytext.ToLower()).ToList();
            ViewBag.anytext = anytext;
            return View(thoseGarages);
        }

        public bool GetRatings([FromBody] CarService model)
        {
            _carAppointmentServices.GetRatings(model);
            return true;
        }

        public IActionResult GetCommentOnRatingsModal(int id)
        {
            var details = _DbContext.CarService.Where(x => x.CarAppointmentId == id).FirstOrDefault();
            return View(details);
        }

        public IActionResult UpdateRating(int id)
        {
            var details = _DbContext.CarService.Where(x => x.CarAppointmentId == id).FirstOrDefault();
            return View(details);
        }

        public IActionResult AdminViewAllCarsServiceHistory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminViewAllCarsServiceHistory(string anytext)
        {
            int userId = int.Parse(userManager.GetUserId(User));
            bool isAdmin = User.IsInRole("Admin");
            var details = _carAppointmentServices.ServiceHistory(userId,isAdmin);
            var thoseGarages = details.Where(x => x.CarNumber.ToLower() == anytext.ToLower()).ToList();
            ViewBag.anytext = anytext;
            return View(thoseGarages);
        }
    }
}
