using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dal.Models
{
    public class MechanicService
    {
        [Key]
        public int mechanicServiceId { get; set; }

        public virtual int? carServiceId { get; set; }

        public bool? serviceStatus { get; set; }

        public DateTime? acceptDate { get; set; }
        public DateTime? estimateDeliveryDate { get; set; }
        public bool? billStatus { get; set; }


        [ForeignKey("carServiceId")]
        public virtual CarService CarService { get; set; }
    }
}
