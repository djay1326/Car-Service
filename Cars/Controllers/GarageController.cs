using Bal;
using Dal;
using Dal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Controllers
{
    [Authorize]
    public class GarageController : Controller
    {
        private readonly CarContext _DbContext;
        private readonly UserManager<Users> userManager;
        private readonly SignInManager<Users> signInManager;
        private readonly RoleManager<IdentityRole<int>> roleManager;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IGarageServices _garageServices;
        public GarageController(CarContext DbContext, UserManager<Users> userManager,
                                SignInManager<Users> signInManager, RoleManager<IdentityRole<int>> roleManager,
                                IWebHostEnvironment webHostEnvironment, IGarageServices garageServices)
        {
            _DbContext = DbContext;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.webHostEnvironment = webHostEnvironment;
            _garageServices = garageServices;
        }
        public IActionResult GarageList()
        {
            int userId = int.Parse(userManager.GetUserId(User));
            ViewBag.Id = userId;
            List<Garage> listOfAllGarages = _garageServices.ListOfAllGaragesforMechanic(userId);
            return View(listOfAllGarages);
        }

        public IActionResult AddGarage(int id)
        {
            ViewBag.UserId = id;
            return View();
        }

        [HttpPost]
        public IActionResult AddGarage(Garage model, int id)
        {
            _garageServices.CreatesGarages(model, id);
            return RedirectToAction("GarageList", "Garage");
        }

        public IActionResult GetServicesModal(int Id)
        {
            var services = _garageServices.GetServicesDetailsModal(Id);
            return View(services);
        }

        public IActionResult UpdateGarageDetailsModal(int id)
        {
            Garage services = _garageServices.GetServicesDetailsModal(id);
            return View(services);
        }

        public bool UpdateGarageDetails([FromBody] Garage update)
        {
            _garageServices.UpdatingGarageDetails(update);
            return true;
        }

        public bool DeleteGarage(int id)
        {
            _garageServices.DeleteGarage(id);
            return true;
        }

        public bool DeleteGarageImage(int id)
        {
            //GarageImages images = _DbContext.GarageImages.Where(x => x.ImageId == id).FirstOrDefault();
            //_DbContext.GarageImages.Remove(images);
            //_DbContext.SaveChanges();
            _garageServices.DeleteGarageImage(id);
            return true;
        }
        public IActionResult UploadMultipleImages(int id)
        {
            ViewBag.Id = id;
            var allImages = _DbContext.GarageImages.Where(x => x.GarageId == id).Select(g => new GarageImages()
                            {
                                ImageId = g.ImageId,
                                GarageId = g.GarageId,
                                ImageUrl = g.ImageUrl,
                            }).ToList();
            ViewBag.img = allImages;
            return View();
        }
        [HttpPost]
        public IActionResult UploadMultipleImages(GarageImages model, int id)
        {
            if (ModelState.IsValid)
            {
                // Logic to store selected Image in folder
                if (model.GalleryFiles != null)
                {
                    string folder = "Garage/Gallery/";
                    model.Gallery = new List<GarageImages>();
                    foreach (IFormFile photo in model.GalleryFiles)
                    {
                        string folderPath = Path.Combine(webHostEnvironment.WebRootPath, folder);
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                        string filePath = Path.Combine(folderPath, uniqueFileName);
                        photo.CopyTo(new FileStream(filePath, FileMode.Create));

                        var images = new GarageImages()
                        {
                            GarageId = id,
                            ImageUrl = uniqueFileName
                        };
                        _DbContext.GarageImages.Add(images);
                        _DbContext.SaveChanges();
                    }
                }

                return RedirectToAction("GarageList", "Garage");
            }
            return View();
        }

        public IActionResult ListAllAvailableGaragesforCustomer()
        {
            //List<Garage> allGarages = _garageServices.ListAllAvailableGaragesforCustomer();
            //var details = (from s in _DbContext.Garage
            //               select new Garage
            //               {
            //                   GarageId = s.GarageId,GarageName = s.GarageName, City = s.City,                  
            //                   AddressLine1 = s.AddressLine1,AddressLine2 = s.AddressLine2,                
            //                   State = s.State,PostalCode = s.PostalCode,
            //                   ImageURL = _DbContext.GarageImages.Where(x => x.GarageId == s.GarageId).FirstOrDefault().ImageUrl,
            //               }).ToList();
            bool isCustomer = User.IsInRole("Customer");
            bool isAdmin = User.IsInRole("Admin");
            var details = _garageServices.ListAllAvailableGaragesforCustomer(isCustomer,isAdmin);
            return View(details);
        }

        public IActionResult ViewGarageDetails(int id)
        {
            TempData["IdValue"] = id;
            GarageAndGarageImagesCustomModel model = new GarageAndGarageImagesCustomModel();
            model.Garage = _DbContext.Garage.Where(x => x.GarageId == id).FirstOrDefault();

            var images = _DbContext.GarageImages.Where(y => y.GarageId == id).Select(g => new GarageImages()
                            {
                                GarageId = g.GarageId,
                                ImageUrl = g.ImageUrl,
                            }).ToList();
            ViewBag.listImages = images;
            return View(model);
        }

        public IActionResult UpdateGarageActiveness(int id,bool status)
        {
            Garage updateStatusOfActiveness = _DbContext.Garage.Where(x => x.GarageId == id).FirstOrDefault();
            updateStatusOfActiveness.IsActive = status;
            _DbContext.Garage.Update(updateStatusOfActiveness);
            _DbContext.SaveChanges();
            return RedirectToAction("ListAllAvailableGaragesforCustomer", "Garage");

        }


    }
}
