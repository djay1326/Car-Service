using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dal.Models
{
    public class Garage
    {
        [Key]
        public int GarageId { get; set; }

        public virtual int UserId { get; set; }

        [Required]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string GarageName { get; set; }

        public int? PickupOrDrop { get; set; }
        [Required]
        public int? ServiceCharge { get; set; }
        public int? WheelBalancing { get; set; }
        public int? WheelAlignment { get; set; }
        public int? WashAndClean { get; set; }
        public int? BodyClean { get; set; }
        public int? PickupAndDrop { get; set; }
        public int? OneSidePickOrDrop { get; set; }
        public int? KeyRegistration { get; set; }

        public bool IsActive { get;set; }
        public bool IsDelete { get;set; }
        public DateTime? CreatedDate { get; set; }
        public TimeSpan? OpenTime { get; set; }
        public TimeSpan? CloseTime { get; set; }

        [NotMapped]
        public string Open { get; set; }
        [NotMapped]
        public string Close { get; set; }
        public int? Price { get; set; }

        [NotMapped]
        public string ImageURL { get; set; }

        [NotMapped]
        public int? ApproxCost { get; set; }

        [NotMapped]
        public string AppointmentDate { get; set; }

        [NotMapped]
        public int? carManufactureId { get; set; }

        [NotMapped]
        public string carModel { get; set; }

        [NotMapped]
        public int? carFuelType { get; set; }
        [NotMapped]
        public string CarNumber { get; set; }
        [NotMapped]
        public string CarName { get; set; }

        [ForeignKey("UserId")]
        public virtual Users Users { get; set; }

        public ICollection<GarageImages> imageGallery { get; set; }
        [NotMapped]
        public decimal? GarageRatings { get; set; }
    }
}
