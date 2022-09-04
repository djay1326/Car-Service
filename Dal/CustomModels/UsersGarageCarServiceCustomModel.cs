using Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal
{
    public class UsersGarageCarServiceCustomModel
    {
        public Users Users { get; set; }
        public Garage Garage { get; set; }

        public CarService CarService { get; set; }
    }
}
