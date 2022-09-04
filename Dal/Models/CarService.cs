using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dal.Models
{
    public class CarService
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarServiceId { get; set; }

        public virtual int? CarAppointmentId { get; set; }

        public int? PaymentStatus { get; set; }

        public DateTime? AcceptDate { get; set; }
        public DateTime? EstimateDeliveryDate { get; set; }

        public string Comments { get; set; }

        public decimal? Ratings { get; set; }
        public DateTime? RatingsDate { get; set; }



        [ForeignKey("CarAppointmentId")]
        public virtual CarAppointment CarAppointment { get; set; }
    }
}
