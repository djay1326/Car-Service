using System;
using System.Collections.Generic;
using System.Text;

namespace Dal
{
       
    public class FirstTableData
    {
        public string UserName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public int? Id { get; set; }
        public string CarModel { get; set; }
        public string CarName { get; set; }
        public string CarNumber { get; set; }
        public int? ServiceStatus { get; set; }
    }
    public class SecondTableData
    {
        public string NameOfUser { get; set; }
        public string UserAddress1 { get; set; }
        public string UserAddress2 { get; set; }
        public string UserCity { get; set; }
        public string UserState { get; set; }
        public string UserPostalCode { get; set; }
        public string CarModel { get; set; }
        public string CarName { get; set; }
        public string CarNumber { get; set; }
        public int IdOfAppointment { get; set; }
        public string GarageName { get; set; }
        public string GarageAdd1 { get; set; }
        public string GarageAdd2 { get; set; }
        public string GarageCity { get; set; }
        public string GarageState { get; set; }
        public string GaragePostalCode { get; set; }
        public int MechanicServiceStatus { get; set; }
    }
    public class ThirdTableData
    {
        public string UserName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public int AppointmentId { get; set; }
        public int ServiceStatus { get; set; }
        public double Ratings { get; set; }
        public string Comments { get; set; }
    }
   
    
    // Remember : Name of column should be same as that in stored Procedure.
}
