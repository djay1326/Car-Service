using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dal.Models
{
    public class CarAppointment
    {
        [Key]
        public int Id { get; set; }

        public virtual int? UserId { get; set; }
        public virtual int GarageId { get; set; }

        public virtual int? CarManufacturerId { get; set; }
        public string CarModel { get; set; }
        public string CarNumber { get; set; }
        public string CarName { get; set; }
        public int? CarFuelType { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public int? ApproxCost { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }

        public int? PickupOrDrop { get; set; }
        public int? ServiceCharge { get; set; }
        public int? WheelBalancing { get; set; }
        public int? WheelAlignment { get; set; }
        public int? WashAndClean { get; set; }
        public int? BodyClean { get; set; }
        public int? PickupAndDrop { get; set; }
        public int? OneSidePickOrDrop { get; set; }
        public int? KeyRegistration { get; set; }

        public int? ServiceStatus { get; set; }

        [NotMapped]
        public bool IsSelected { get; set; }

        [ForeignKey("UserId")]
        public virtual Users Users { get; set; }

        [ForeignKey("GarageId")]
        public virtual Garage Garage { get; set; }

        [ForeignKey("CarManufacturerId")]
        public virtual CarManufacturers CarManufacurers { get; set; }

        [NotMapped]
        public string AddressLine1 { get; set; }
        [NotMapped]
        public string AddressLine2 { get; set; }
        [NotMapped]
        public string City { get; set; }
        [NotMapped]
        public string State { get; set; }
        [NotMapped]
        public string PostalCode { get; set; }
        [NotMapped]
        public string GarageName { get; set; }
        [NotMapped]
        public string NameOfUser { get; set; }
        [NotMapped]
        public string UserEmail { get; set; }
        [NotMapped]
        public string UserPhoneNo { get; set; }
        [NotMapped]
        public string UserAddressLine1 { get; set; }
        [NotMapped]
        public string UserAddressLine2 { get; set; }
        [NotMapped]
        public string UserCity { get; set; }
        [NotMapped]
        public string UserState { get; set; }
        [NotMapped]
        public string UserPostalCode { get; set; }
        [NotMapped]
        public string ApptDate { get; set; }
        [NotMapped]
        public int? InvoiceCarAppointmentId { get; set; }

        [NotMapped]
        public DateTime? AppointmentAcceptDate { get; set; }

        [NotMapped]
        public int? StatusOfPayment { get; set; }

        [NotMapped]
        public string SearchText { get; set; }
        [NotMapped]
        public string SearchPaymentStatus { get; set; }

        [NotMapped]
        public DateTime SearchDate { get; set; }

        [NotMapped]
        public String SearchStatus { get; set; }
        [NotMapped]
        public int? Total_Cost { get; set; }
        [NotMapped]
        public List<ServiceWork> WorkDone { get; set; }
        [NotMapped]
        public List<ServiceWork> PriceOfService { get; set; }

        [NotMapped]
        public decimal? RatingsGiven { get; set; }
        [NotMapped]
        public string CommentGiven { get; set; }
    }
}
