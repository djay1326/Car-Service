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
    public class GarageServices : IGarageServices
    {
        private readonly CarContext _DbContext;
        private readonly UserManager<Users> userManager;
        private readonly RoleManager<IdentityRole<int>> roleManager;

        public GarageServices(CarContext DbContext, UserManager<Users> userManager,
                                RoleManager<IdentityRole<int>> roleManager
                                )
        {
            _DbContext = DbContext;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public List<Garage> ListOfAllGaragesforMechanic(int userId)
        {
            //List<Garage> listOfAllGarages = _DbContext.Garage.Where(x=>x.UserId == userId).ToList();
            List<Garage> listOfAllGarages = _DbContext.Garage.Where(x=>x.UserId == userId).Select(s => new Garage() {
                                            GarageId = s.GarageId,
                                            GarageName = s.GarageName,
                                            AddressLine1 = s.AddressLine1,
                                            AddressLine2 = s.AddressLine2,
                                            City = s.City,
                                            State = s.State,
                                            IsActive = s.IsActive,
                                            PostalCode = s.PostalCode,
                                            OpenTime = s.OpenTime,
                                            CloseTime = s.CloseTime,
                                            GarageRatings = Convert.ToDecimal((from p in _DbContext.CarService
                                                                               join q in _DbContext.CarAppointment
                                                                               on p.CarAppointmentId equals q.Id
                                                                               where q.GarageId == s.GarageId
                                                                               select p.Ratings).ToArray().Average()),
                                            }).ToList();
            return listOfAllGarages;
        }
        public List<Garage> ListAllGaragesByParameters(int serviceCharge, string city)
        {
            List<Garage> listAllGaragesByParameters = _DbContext.Garage.Where(x => (x.ServiceCharge <= serviceCharge) || (x.City == city)).ToList();
            return listAllGaragesByParameters;
        }

        public Garage GetServicesDetailsModal(int Id)
        {
            var services = _DbContext.Garage.Where(x => x.GarageId == Id).FirstOrDefault();
            return services;
        }
        
        public void UpdatingGarageDetails([FromBody] Garage model)
        {
            Garage values = _DbContext.Garage.Where(x => x.GarageId == model.GarageId).FirstOrDefault();
            values.AddressLine1 = model.AddressLine1;
            values.AddressLine2 = model.AddressLine2;
            values.City = model.City;
            values.State = model.State;
            values.PostalCode = model.PostalCode;
            values.OpenTime = TimeSpan.Parse(model.Open);
            values.CloseTime = TimeSpan.Parse(model.Close);

            values.ServiceCharge = model.ServiceCharge;
            values.KeyRegistration = model.KeyRegistration;
            values.WashAndClean = model.WashAndClean;
            values.WheelAlignment = model.WheelAlignment;
            values.WheelBalancing = model.WheelBalancing;
            values.PickupAndDrop = model.PickupAndDrop;
            values.PickupOrDrop = model.PickupOrDrop;
            values.OneSidePickOrDrop = model.OneSidePickOrDrop;
            values.BodyClean = model.BodyClean;
            values.GarageName = model.GarageName;
            _DbContext.Garage.Update(values);
            _DbContext.SaveChanges();
        }

        public void DeleteGarage(int i)
        {
            Garage values = _DbContext.Garage.Where(x => x.GarageId == i).FirstOrDefault();
            _DbContext.Garage.Remove(values);
            _DbContext.SaveChanges();
        }

        public void DeleteGarageImage(int id)
        {
            GarageImages images = _DbContext.GarageImages.Where(x => x.ImageId == id).FirstOrDefault();
            _DbContext.GarageImages.Remove(images);
            _DbContext.SaveChanges();
        }
        public Garage GarageByGarageId(int garageid)
        {
            var garageByGarageId = (from s in _DbContext.Garage
                                    where s.GarageId == garageid
                                    select new Garage
                                    {
                                        GarageName = s.GarageName,
                                        AddressLine1 = s.AddressLine1,
                                        AddressLine2 = s.AddressLine2,
                                        City = s.City,
                                        State = s.State,
                                        PostalCode = s.PostalCode,
                                        OpenTime = s.OpenTime,
                                        CloseTime = s.CloseTime,
                                        BodyClean = s.BodyClean,
                                        WheelBalancing = s.WheelBalancing,
                                        WashAndClean = s.WashAndClean,
                                        WheelAlignment = s.WheelAlignment
                                    }).FirstOrDefault();
            return garageByGarageId;
        }
        public void CreatesGarages(Garage garage, int userId)
        {
            garage.UserId = userId;
            garage.CreatedDate = DateTime.UtcNow;
            garage.IsActive = true;
            _DbContext.Garage.Add(garage);
            _DbContext.SaveChanges();
        }

        public List<Garage> ListAllAvailableGaragesforCustomer(bool isCustomer,bool isAdmin)
        {
            if(isCustomer == true)
            {
                var info = _DbContext.Garage.Where(x => x.IsActive && !x.IsDelete).Select(s => new Garage()
                {
                    GarageId = s.GarageId,
                    GarageName = s.GarageName,
                    AddressLine1 = s.AddressLine1,
                    AddressLine2 = s.AddressLine2,
                    City = s.City,
                    State = s.State,
                    IsActive = s.IsActive,
                    PostalCode = s.PostalCode,
                    ImageURL = (_DbContext.GarageImages.FirstOrDefault(x => x.GarageId == s.GarageId) != null) ? _DbContext.GarageImages.FirstOrDefault(x => x.GarageId == s.GarageId).ImageUrl : "",
                    GarageRatings = Convert.ToDecimal((from p in _DbContext.CarService
                                                       join q in _DbContext.CarAppointment
                                                       on p.CarAppointmentId equals q.Id
                                                       where q.GarageId == s.GarageId
                                                       select p.Ratings).ToArray().Average()),

                }).ToList();

                return info;
            }

            var details = _DbContext.Garage.Select(s => new Garage()
                                                {
                                                    GarageId = s.GarageId,
                                                    GarageName = s.GarageName,
                                                    AddressLine1 = s.AddressLine1,
                                                    AddressLine2 = s.AddressLine2,
                                                    City = s.City,
                                                    State = s.State,
                                                    IsActive = s.IsActive,
                                                    PostalCode = s.PostalCode,
                                                    ImageURL = (_DbContext.GarageImages.FirstOrDefault(x => x.GarageId == s.GarageId) != null) ? _DbContext.GarageImages.FirstOrDefault(x => x.GarageId == s.GarageId).ImageUrl : "",
                                                    GarageRatings = Convert.ToDecimal((from p in _DbContext.CarService
                                                                                       join q in _DbContext.CarAppointment
                                                                                       on p.CarAppointmentId equals q.Id
                                                                                       where q.GarageId == s.GarageId
                                                                                       select p.Ratings).ToArray().Average()),

                                                }).ToList();

            return details;
        }
    }
}
