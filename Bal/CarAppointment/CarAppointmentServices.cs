using Dal;
using Dal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bal
{
    public class CarAppointmentServices : ICarAppointmentServices
    {
        private readonly CarContext _DbContext;
        private readonly UserManager<Users> userManager;
        private readonly RoleManager<IdentityRole<int>> roleManager;

        public CarAppointmentServices(CarContext DbContext, UserManager<Users> userManager,
                                RoleManager<IdentityRole<int>> roleManager
                                )
        {
            _DbContext = DbContext;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public void CustomerMakesAppointment(CarAppointment carAppointment, int userId)
        {
            carAppointment.ApproxCost = carAppointment.WashAndClean + carAppointment.BodyClean + carAppointment.WheelAlignment + carAppointment.WheelBalancing;
            _DbContext.CarAppointment.Add(carAppointment);
            _DbContext.SaveChanges();
        }

        public void PostMethodofCustomerMakesAppointment([FromBody] Garage model, int userid)
        {
            CarAppointment values = new CarAppointment();
            values.UserId = userid;
            values.GarageId = model.GarageId;
            values.AppointmentDate = DateTime.Parse(model.AppointmentDate);
            values.ServiceCharge = model.ServiceCharge;
            values.KeyRegistration = model.KeyRegistration;
            values.WashAndClean = model.WashAndClean;
            values.WheelAlignment = model.WheelAlignment;
            values.WheelBalancing = model.WheelBalancing;
            values.PickupAndDrop = model.PickupAndDrop;
            values.PickupOrDrop = model.PickupOrDrop;
            values.OneSidePickOrDrop = model.OneSidePickOrDrop;
            values.BodyClean = model.BodyClean;
            values.ApproxCost = model.ApproxCost;

            values.ServiceStatus = 1;

            values.CarName = model.CarName;
            values.CarNumber = model.CarNumber;
            values.CarManufacturerId = model.carManufactureId;
            values.CarModel = model.carModel;
            values.CarFuelType = model.carFuelType;
            _DbContext.CarAppointment.Add(values);
            _DbContext.SaveChanges();
            //List<CarAppointment> customerSeeCurrentAppointmentStatus = _DbContext.CarAppointment.Where(x => x.UserId == userid).ToList();
            //return customerSeeCurrentAppointmentStatus;
        }
        public List<CarAppointment> ListAllAppointmentsOfCustomer(int userId, bool isAdmin)
        {
            if(isAdmin == true)
            {
                var allAppointments = (from s in _DbContext.CarAppointment
                                       join q in _DbContext.Garage
                                        on s.GarageId equals q.GarageId
                                        join r in _DbContext.Users
                                        on q.UserId equals r.Id
                                       select new CarAppointment
                                       {
                                           Id = s.Id,
                                           UserId = s.UserId,
                                           GarageId = s.GarageId,
                                           CarManufacturerId = s.CarManufacturerId,
                                           CarModel = s.CarModel,
                                           CarName = s.CarName,
                                           CarNumber = s.CarNumber,
                                           CarFuelType = s.CarFuelType,
                                           ApproxCost = s.ApproxCost,
                                           AppointmentDate = s.AppointmentDate,
                                           GarageName = _DbContext.Garage.Where(x => x.GarageId == s.GarageId).FirstOrDefault().GarageName,
                                           AddressLine1 = _DbContext.Garage.Where(x => x.GarageId == s.GarageId).FirstOrDefault().AddressLine1,
                                           AddressLine2 = _DbContext.Garage.Where(x => x.GarageId == s.GarageId).FirstOrDefault().AddressLine2,
                                           City = _DbContext.Garage.Where(x => x.GarageId == s.GarageId).FirstOrDefault().City,
                                           State = _DbContext.Garage.Where(x => x.GarageId == s.GarageId).FirstOrDefault().State,
                                           PostalCode = _DbContext.Garage.Where(x => x.GarageId == s.GarageId).FirstOrDefault().PostalCode,
                                           ServiceStatus = s.ServiceStatus,

                                           NameOfUser = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().Name,
                                           UserAddressLine1 = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().AddressLine1,
                                           UserAddressLine2 = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().AddressLine2,
                                           UserCity = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().City,
                                           UserState = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().State,
                                           UserPostalCode = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().PostalCode,
                                           UserEmail = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().UserName,
                                           UserPhoneNo = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().PhoneNumber,

                                           AppointmentAcceptDate = _DbContext.CarService.Where(x => x.CarAppointmentId == s.Id).FirstOrDefault().AcceptDate,
                                           StatusOfPayment = _DbContext.CarService.Where(x => x.CarAppointmentId == s.Id).FirstOrDefault().PaymentStatus,
                                           RatingsGiven = _DbContext.CarService.Where(x => x.CarAppointmentId == s.Id).FirstOrDefault().Ratings,
                                           CommentGiven = _DbContext.CarService.Where(x => x.CarAppointmentId == s.Id).FirstOrDefault().Comments,
                                           InvoiceCarAppointmentId = _DbContext.InvoiceInfo.Where(x => x.CarAppointmentId == s.Id).FirstOrDefault().CarAppointmentId,
                                       }).ToList();
                return allAppointments;
            }
            var myAppointments = (from s in _DbContext.CarAppointment
                                  where s.UserId == userId
                                  select new CarAppointment
                                  {
                                      Id = s.Id,
                                      UserId = s.UserId,
                                      GarageId = s.GarageId,
                                      CarManufacturerId = s.CarManufacturerId,
                                      CarModel = s.CarModel,
                                      CarName = s.CarName,
                                      CarNumber = s.CarNumber,
                                      CarFuelType = s.CarFuelType,
                                      ApproxCost = s.ApproxCost,
                                      AppointmentDate = s.AppointmentDate,
                                      GarageName = _DbContext.Garage.Where(x => x.GarageId == s.GarageId).FirstOrDefault().GarageName,
                                      AddressLine1 = _DbContext.Garage.Where(x => x.GarageId == s.GarageId).FirstOrDefault().AddressLine1,
                                      AddressLine2 = _DbContext.Garage.Where(x => x.GarageId == s.GarageId).FirstOrDefault().AddressLine2,
                                      City = _DbContext.Garage.Where(x => x.GarageId == s.GarageId).FirstOrDefault().City,
                                      State = _DbContext.Garage.Where(x => x.GarageId == s.GarageId).FirstOrDefault().State,
                                      PostalCode = _DbContext.Garage.Where(x => x.GarageId == s.GarageId).FirstOrDefault().PostalCode,
                                      ServiceStatus = s.ServiceStatus
                                  }).ToList();
            return myAppointments;
        }

        

        public List<CarAppointment> ListAppointmentRequestsforMechanic(int userId)
        {
            var myAppointments = (from s in _DbContext.CarAppointment
                                  join q in _DbContext.Garage
                                  on s.GarageId equals q.GarageId
                                  join r in _DbContext.Users
                                  on q.UserId equals r.Id
                                  where r.Id == userId && (s.ServiceStatus == 1 || s.ServiceStatus == 3)
                                  select new CarAppointment
                                  {
                                      Id = s.Id,
                                      UserId = s.UserId,
                                      GarageId = s.GarageId,
                                      CarManufacturerId = s.CarManufacturerId,
                                      CarModel = s.CarModel,
                                      CarName = s.CarName,
                                      CarNumber = s.CarNumber,
                                      CarFuelType = s.CarFuelType,
                                      ApproxCost = s.ApproxCost,
                                      AppointmentDate = s.AppointmentDate,
                                      ServiceStatus = s.ServiceStatus,
                                      GarageName = _DbContext.Garage.Where(x => x.GarageId == s.GarageId).FirstOrDefault().GarageName,
                                      AddressLine1 = _DbContext.Garage.Where(x => x.GarageId == s.GarageId).FirstOrDefault().AddressLine1,
                                      AddressLine2 = _DbContext.Garage.Where(x => x.GarageId == s.GarageId).FirstOrDefault().AddressLine2,
                                      City = _DbContext.Garage.Where(x => x.GarageId == s.GarageId).FirstOrDefault().City,
                                      State = _DbContext.Garage.Where(x => x.GarageId == s.GarageId).FirstOrDefault().State,
                                      PostalCode = _DbContext.Garage.Where(x => x.GarageId == s.GarageId).FirstOrDefault().PostalCode,

                                      NameOfUser = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().Name,
                                      UserAddressLine1 = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().AddressLine1,
                                      UserAddressLine2 = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().AddressLine2,
                                      UserCity = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().City,
                                      UserState = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().State,
                                      UserPostalCode = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().PostalCode,
                                      UserEmail = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().UserName,
                                      UserPhoneNo = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().PhoneNumber
                                  }).ToList();
            return myAppointments;
        }


        public void UpdateBookedAppointment([FromBody] CarAppointment model)
        {
            CarAppointment values = _DbContext.CarAppointment.Where(x => x.Id == model.Id).FirstOrDefault();

            values.AppointmentDate = DateTime.Parse(model.ApptDate);
            values.ServiceCharge = model.ServiceCharge;
            values.KeyRegistration = model.KeyRegistration;
            values.WashAndClean = model.WashAndClean;
            values.WheelAlignment = model.WheelAlignment;
            values.WheelBalancing = model.WheelBalancing;
            values.PickupAndDrop = model.PickupAndDrop;
            values.PickupOrDrop = model.PickupOrDrop;
            values.OneSidePickOrDrop = model.OneSidePickOrDrop;
            values.BodyClean = model.BodyClean;
            values.ApproxCost = model.ApproxCost;

            values.CarName = model.CarName;
            values.CarNumber = model.CarNumber;


            values.CarManufacturerId = model.CarManufacturerId;
            values.CarModel = model.CarModel;
            values.CarFuelType = model.CarFuelType;
            _DbContext.CarAppointment.Update(values);
            _DbContext.SaveChanges();
            
        }

        
        public void DeleteAppointment(int id)
        {
            CarAppointment values = _DbContext.CarAppointment.Where(x => x.Id == id).FirstOrDefault();
            _DbContext.CarAppointment.Remove(values);
            _DbContext.SaveChanges();
        }

        public void UpdateAppointmentStatus(int appointmentId, int status/*int? status = null*/)
        {
            CarAppointment statusChange = _DbContext.CarAppointment.Where(x => x.Id == appointmentId).FirstOrDefault();
            statusChange.ServiceStatus = status;
            _DbContext.CarAppointment.Update(statusChange);
            _DbContext.SaveChanges();

            if(status == 2)
            {
                CarService details = new CarService();
                details.CarAppointmentId = appointmentId;
                details.AcceptDate = DateTime.UtcNow;
                details.PaymentStatus = 1;
                _DbContext.CarService.Add(details);
                _DbContext.SaveChanges();
            }
            
        }
        public void UpdatePaymentStatus(int id)
        {
            CarService value = _DbContext.CarService.Where(x => x.CarAppointmentId == id).FirstOrDefault();
            value.PaymentStatus = 2;
            _DbContext.CarService.Update(value);
            _DbContext.SaveChanges();
        }
        public List<CarAppointment> ListApprovedAppointments(int userId)
        {
            var approvedAppointments = (from s in _DbContext.CarAppointment
                                        join q in _DbContext.Garage
                                        on s.GarageId equals q.GarageId
                                        join r in _DbContext.Users
                                        on q.UserId equals r.Id
                                        where r.Id == userId && (s.ServiceStatus == 2 || s.ServiceStatus == 4 || s.ServiceStatus == 5 || s.ServiceStatus == 6)
                                        select new CarAppointment
                                        {
                                            Id = s.Id,
                                            UserId = s.UserId,
                                            GarageId = s.GarageId,
                                            InvoiceCarAppointmentId = _DbContext.InvoiceInfo.Where(x=>x.CarAppointmentId == s.Id).FirstOrDefault().CarAppointmentId,
                                            CarManufacturerId = s.CarManufacturerId,
                                            CarModel = s.CarModel,
                                            CarName = s.CarName,
                                            CarNumber = s.CarNumber,
                                            CarFuelType = s.CarFuelType,
                                            ApproxCost = s.ApproxCost,
                                            AppointmentDate = s.AppointmentDate,
                                            ServiceStatus = s.ServiceStatus,

                                            GarageName = _DbContext.Garage.Where(x => x.GarageId == s.GarageId).FirstOrDefault().GarageName,
                                            AddressLine1 = _DbContext.Garage.Where(x => x.GarageId == s.GarageId).FirstOrDefault().AddressLine1,
                                            AddressLine2 = _DbContext.Garage.Where(x => x.GarageId == s.GarageId).FirstOrDefault().AddressLine2,
                                            City = _DbContext.Garage.Where(x => x.GarageId == s.GarageId).FirstOrDefault().City,
                                            State = _DbContext.Garage.Where(x => x.GarageId == s.GarageId).FirstOrDefault().State,
                                            PostalCode = _DbContext.Garage.Where(x => x.GarageId == s.GarageId).FirstOrDefault().PostalCode,

                                            NameOfUser = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().Name,
                                            UserAddressLine1 = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().AddressLine1,
                                            UserAddressLine2 = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().AddressLine2,
                                            UserCity = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().City,
                                            UserState = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().State,
                                            UserPostalCode = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().PostalCode,
                                            UserEmail = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().UserName,
                                            UserPhoneNo = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().PhoneNumber,

                                            AppointmentAcceptDate = _DbContext.CarService.Where(x=> x.CarAppointmentId == s.Id).FirstOrDefault().AcceptDate,
                                            StatusOfPayment = _DbContext.CarService.Where(x => x.CarAppointmentId == s.Id).FirstOrDefault().PaymentStatus,
                                            RatingsGiven = _DbContext.CarService.Where(x => x.CarAppointmentId == s.Id).FirstOrDefault().Ratings,
                                            CommentGiven = _DbContext.CarService.Where(x => x.CarAppointmentId == s.Id).FirstOrDefault().Comments
                                        }).ToList();
            return approvedAppointments;
        }

        public List<CarAppointment> CustomersServices(int userId)
        {
            var myAppointments = (from s in _DbContext.CarAppointment
                                  where s.UserId == userId && (s.ServiceStatus == 2 || s.ServiceStatus == 4 || s.ServiceStatus == 5 || s.ServiceStatus == 6)
                                  select new CarAppointment
                                  {
                                      Id = s.Id,
                                      UserId = s.UserId,
                                      GarageId = s.GarageId,
                                      InvoiceCarAppointmentId = _DbContext.InvoiceInfo.Where(x => x.CarAppointmentId == s.Id).FirstOrDefault().CarAppointmentId,
                                      CarManufacturerId = s.CarManufacturerId,
                                      CarModel = s.CarModel,
                                      CarName = s.CarName,
                                      CarNumber = s.CarNumber,
                                      CarFuelType = s.CarFuelType,
                                      ApproxCost = s.ApproxCost,
                                      AppointmentDate = s.AppointmentDate,
                                      ServiceStatus = s.ServiceStatus,

                                      GarageName = _DbContext.Garage.Where(x => x.GarageId == s.GarageId).FirstOrDefault().GarageName,
                                      AddressLine1 = _DbContext.Garage.Where(x => x.GarageId == s.GarageId).FirstOrDefault().AddressLine1,
                                      AddressLine2 = _DbContext.Garage.Where(x => x.GarageId == s.GarageId).FirstOrDefault().AddressLine2,
                                      City = _DbContext.Garage.Where(x => x.GarageId == s.GarageId).FirstOrDefault().City,
                                      State = _DbContext.Garage.Where(x => x.GarageId == s.GarageId).FirstOrDefault().State,
                                      PostalCode = _DbContext.Garage.Where(x => x.GarageId == s.GarageId).FirstOrDefault().PostalCode,

                                      NameOfUser = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().Name,
                                      UserAddressLine1 = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().AddressLine1,
                                      UserAddressLine2 = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().AddressLine2,
                                      UserCity = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().City,
                                      UserState = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().State,
                                      UserPostalCode = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().PostalCode,
                                      UserEmail = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().UserName,
                                      UserPhoneNo = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().PhoneNumber,

                                      AppointmentAcceptDate = _DbContext.CarService.Where(x => x.CarAppointmentId == s.Id).FirstOrDefault().AcceptDate,
                                      StatusOfPayment = _DbContext.CarService.Where(x => x.CarAppointmentId == s.Id).FirstOrDefault().PaymentStatus,
                                      RatingsGiven = _DbContext.CarService.Where(x => x.CarAppointmentId == s.Id).FirstOrDefault().Ratings
                                  }).ToList();
            return myAppointments;
        }

        public List<CarAppointment> ServiceHistory(int userId,bool isAdmin)
        {
            if(isAdmin == true)
            {
                var allHistory = (from s in _DbContext.CarAppointment
                               join t in _DbContext.CarService
                               on s.Id equals t.CarAppointmentId
                               where s.ServiceStatus == 6 && t.PaymentStatus == 2
                               select new CarAppointment
                               {
                                   Id = s.Id,
                                   UserId = s.UserId,
                                   GarageId = s.GarageId,
                                   InvoiceCarAppointmentId = _DbContext.InvoiceInfo.Where(x => x.CarAppointmentId == s.Id).FirstOrDefault().CarAppointmentId,
                                   CarManufacturerId = s.CarManufacturerId,
                                   CarModel = s.CarModel,
                                   CarName = s.CarName,
                                   CarNumber = s.CarNumber,
                                   CarFuelType = s.CarFuelType,
                                   ApproxCost = s.ApproxCost,
                                   AppointmentDate = s.AppointmentDate,
                                   ServiceStatus = s.ServiceStatus,

                                   GarageName = _DbContext.Garage.Where(x => x.GarageId == s.GarageId).FirstOrDefault().GarageName,
                                   AddressLine1 = _DbContext.Garage.Where(x => x.GarageId == s.GarageId).FirstOrDefault().AddressLine1,
                                   AddressLine2 = _DbContext.Garage.Where(x => x.GarageId == s.GarageId).FirstOrDefault().AddressLine2,
                                   City = _DbContext.Garage.Where(x => x.GarageId == s.GarageId).FirstOrDefault().City,
                                   State = _DbContext.Garage.Where(x => x.GarageId == s.GarageId).FirstOrDefault().State,
                                   PostalCode = _DbContext.Garage.Where(x => x.GarageId == s.GarageId).FirstOrDefault().PostalCode,

                                   NameOfUser = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().Name,
                                   UserAddressLine1 = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().AddressLine1,
                                   UserAddressLine2 = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().AddressLine2,
                                   UserCity = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().City,
                                   UserState = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().State,
                                   UserPostalCode = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().PostalCode,
                                   UserEmail = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().UserName,
                                   UserPhoneNo = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().PhoneNumber,

                                   AppointmentAcceptDate = _DbContext.CarService.Where(x => x.CarAppointmentId == s.Id).FirstOrDefault().AcceptDate,
                                   StatusOfPayment = _DbContext.CarService.Where(x => x.CarAppointmentId == s.Id).FirstOrDefault().PaymentStatus,
                                   Total_Cost = _DbContext.InvoiceInfo.Where(x => x.CarAppointmentId == s.Id).FirstOrDefault().TotalPrice,

                                   WorkDone = _DbContext.ServiceWork.Where(x => x.CarAppointmentId == s.Id).ToList()
                               }).ToList();
                return allHistory;
            }
            var details = (from s in _DbContext.CarAppointment
                           join t in _DbContext.CarService
                           on s.Id equals t.CarAppointmentId
                                  where s.UserId == userId && s.ServiceStatus == 6 && t.PaymentStatus == 2
                                  select new CarAppointment
                                  {
                                      Id = s.Id,
                                      UserId = s.UserId,
                                      GarageId = s.GarageId,
                                      InvoiceCarAppointmentId = _DbContext.InvoiceInfo.Where(x => x.CarAppointmentId == s.Id).FirstOrDefault().CarAppointmentId,
                                      CarManufacturerId = s.CarManufacturerId,
                                      CarModel = s.CarModel,
                                      CarName = s.CarName,
                                      CarNumber = s.CarNumber,
                                      CarFuelType = s.CarFuelType,
                                      ApproxCost = s.ApproxCost,
                                      AppointmentDate = s.AppointmentDate,
                                      ServiceStatus = s.ServiceStatus,

                                      GarageName = _DbContext.Garage.Where(x => x.GarageId == s.GarageId).FirstOrDefault().GarageName,
                                      AddressLine1 = _DbContext.Garage.Where(x => x.GarageId == s.GarageId).FirstOrDefault().AddressLine1,
                                      AddressLine2 = _DbContext.Garage.Where(x => x.GarageId == s.GarageId).FirstOrDefault().AddressLine2,
                                      City = _DbContext.Garage.Where(x => x.GarageId == s.GarageId).FirstOrDefault().City,
                                      State = _DbContext.Garage.Where(x => x.GarageId == s.GarageId).FirstOrDefault().State,
                                      PostalCode = _DbContext.Garage.Where(x => x.GarageId == s.GarageId).FirstOrDefault().PostalCode,

                                      NameOfUser = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().Name,
                                      UserAddressLine1 = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().AddressLine1,
                                      UserAddressLine2 = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().AddressLine2,
                                      UserCity = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().City,
                                      UserState = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().State,
                                      UserPostalCode = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().PostalCode,
                                      UserEmail = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().UserName,
                                      UserPhoneNo = _DbContext.Users.Where(x => x.Id == s.UserId).FirstOrDefault().PhoneNumber,

                                      AppointmentAcceptDate = _DbContext.CarService.Where(x => x.CarAppointmentId == s.Id).FirstOrDefault().AcceptDate,
                                      StatusOfPayment = _DbContext.CarService.Where(x => x.CarAppointmentId == s.Id).FirstOrDefault().PaymentStatus,
                                      Total_Cost = _DbContext.InvoiceInfo.Where(x => x.CarAppointmentId == s.Id).FirstOrDefault().TotalPrice,

                                      WorkDone = _DbContext.ServiceWork.Where(x => x.CarAppointmentId == s.Id).ToList()
                                  }).ToList();
            return details;
        }

        public List<CarAppointment> ListServiceHistory(int loggedinUser)
        {
            List<CarAppointment> listServiceHistory = _DbContext.CarAppointment.Where(x => (x.UserId == loggedinUser) && (x.ServiceStatus == 2)).ToList();
            return listServiceHistory;
        }

        public void GetRatings([FromBody] CarService model)
        {
            CarService data = _DbContext.CarService.Where(x => x.CarAppointmentId == model.CarAppointmentId).FirstOrDefault();

            data.Ratings = model.Ratings;
            data.RatingsDate = DateTime.UtcNow;
            data.Comments = model.Comments;
            _DbContext.CarService.Update(data);

            _DbContext.SaveChanges();
        }
    }
}
