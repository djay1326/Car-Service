using Dal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal
{
    public partial  class CarContext : IdentityDbContext<Users, IdentityRole<int>, int>
    {
        public CarContext()
        {

        }

        public CarContext(DbContextOptions<CarContext> options)
            : base(options)
        {
        }

        
        public virtual DbSet<Garage> Garage { get; set; }
        public virtual DbSet<CarAppointment> CarAppointment { get; set; }
        public virtual DbSet<CarManufacturers> CarManufacturers { get; set; }
        public virtual DbSet<CarService> CarService { get; set; }
        public virtual DbSet<ServiceWork> ServiceWork { get; set; }
        public virtual DbSet<InvoiceInfo> InvoiceInfo { get; set; }
        public virtual DbSet<GarageImages> GarageImages { get; set; }
    }
}
