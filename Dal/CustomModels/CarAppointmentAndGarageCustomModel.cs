using Dal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dal.CustomModels
{
    public class CarAppointmentAndGarageCustomModel
    {
        public Garage Garage { get; set; }
        public CarAppointment CarAppointment { get; set; }

        public CarManufacturers CarManufacturers { get; set; }

        //[Key]
        //public int GarageId { get; set; }

        //public virtual int UserId { get; set; }

        //[Required]
        //public string AddressLine1 { get; set; }
        //public string AddressLine2 { get; set; }
        //[Required]
        //public string City { get; set; }
        //public string State { get; set; }
        //[Required]
        //public string PostalCode { get; set; }
        //[Required]
        //public string GarageName { get; set; }

        //public int? PickupOrDrop { get; set; }
        //public int? ServiceCharge { get; set; }
        //public int? WheelBalancing { get; set; }
        //public int? WheelAlignment { get; set; }
        //public int? WashAndClean { get; set; }
        //public int? BodyClean { get; set; }
        //public int? PickupAndDrop { get; set; }
        //public int? OneSidePickOrDrop { get; set; }
        //public int? KeyRegistration { get; set; }

        //public bool IsActive { get; set; }
        //public bool IsDelete { get; set; }
        //public DateTime? CreatedDate { get; set; }
        //public TimeSpan? OpenTime { get; set; }
        //public TimeSpan? CloseTime { get; set; }

        //[NotMapped]
        //public string Open { get; set; }
        //[NotMapped]
        //public string Close { get; set; }
        //public int? Price { get; set; }

        //[NotMapped]
        //public string ImageURL { get; set; }



        //[Key]
        //public int Id { get; set; }



        //public virtual int? CarManufacturerId { get; set; }
        //public string CarModel { get; set; }
        //public int? CarFuelType { get; set; }
        //public DateTime? AppointmentDate { get; set; }
        //public int? ApproxCost { get; set; }



        //public int? ServiceStatus { get; set; }

        //[NotMapped]
        //public bool IsSelected { get; set; }




    }
}
