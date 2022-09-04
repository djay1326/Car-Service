using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dal.Models
{
    public class ServiceWork
    {
        [Key]
        public int WorkId { get; set; }
        public virtual int? CarServiceId { get; set; }
        public virtual int? CarAppointmentId { get; set; }
        public string Work { get; set; }

        public int? Price { get; set; }

        [NotMapped]
        public int? CarAppointmentIdInvoice { get; set; }

        [ForeignKey("CarServiceId")]
        public virtual CarService CarService { get; set; }
        [ForeignKey("CarAppointmentId")]
        public virtual CarAppointment CarAppointment { get; set; }
    }
}
