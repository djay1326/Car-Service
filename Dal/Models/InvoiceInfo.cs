using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dal.Models
{
    public class InvoiceInfo
    {
        [Key]
        public int InvoiceId { get; set; }

        public virtual int UserId { get; set; }
        public virtual int GarageId { get; set; }
        //public virtual int CarServiceId { get; set; }
        public virtual int? CarAppointmentId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? PostalCode { get; set; }
        public string Email { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? Price { get; set; }
        public int? Tax { get; set; }
        public int? TotalPrice { get; set; }
        public int? Status { get; set; }

        [ForeignKey("UserId")]
        public virtual Users Users { get; set; }

        [ForeignKey("GarageId")]
        public virtual Garage Garage { get; set; }

        //[ForeignKey("CarServiceId")]
        //public virtual CarService CarService { get; set; }

        [ForeignKey("CarAppointmentId")]
        public virtual CarAppointment CarAppointment { get; set; }
    }
}
