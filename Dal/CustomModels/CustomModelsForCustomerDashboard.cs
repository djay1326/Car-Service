using System;
using System.Collections.Generic;
using System.Text;

namespace Dal
{
    public class CustomModelsForCustomerDashboard
    {
        public int TotalAppointments { get; set; }

        public int CompletedAppointments { get; set; }

        public int PendingAppointments { get; set; }

        public IEnumerable<DataOfFirstTable> DataOfFirstTable { get; set; }

        public IEnumerable<DataOfSecondTable> DataOfSecondTable { get; set; }
    }

    public class DataOfFirstTable
    {
        public string GarageName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GarageId { get; set; }
        public int CarManufacturerId { get; set; }
        public string CarModel { get; set; }
        public string CarName { get; set; }
        public string CarNumber { get; set; }
        public int CarFuelType { get; set; }
        public int ApproxCost { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int ServiceStatus { get; set; }
    }

    public class DataOfSecondTable
    {
        public string GarageName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GarageId { get; set; }
        public int CarManufacturerId { get; set; }
        public string CarModel { get; set; }
        public string CarName { get; set; }
        public string CarNumber { get; set; }
        public int CarFuelType { get; set; }
        public int ApproxCost { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int ServiceStatus { get; set; }
        public int PaymentStatus { get; set; }
        public double Ratings { get; set; }
    }
}
