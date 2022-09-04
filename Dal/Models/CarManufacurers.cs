using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dal.Models
{
    public class CarManufacturers
    {
        [Key]
        public int CarManufacturerId { get; set; }

        public string NameOfCar { get; set; }
    }
}
