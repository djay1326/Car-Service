using System;
using System.Collections.Generic;
using System.Text;

namespace Dal
{
        public class AdminDashboardData
        {

        }
        public class FirstTableValues
        {
            public int? GarageId { get; set; }
            public string GarageName { get; set; }
            public string AddressLine1 { get; set; }
            public string AddressLine2 { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string PostalCode { get; set; }
            public string OpenTime { get; set; }
            public string CloseTime { get; set; }
        }

    public class SecondTableValues
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PhoneNumber { get; set; }
        public string PostalCode { get; set; }
    }
    public class ThirdTableValues
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
}
