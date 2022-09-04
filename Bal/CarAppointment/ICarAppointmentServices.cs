using Dal.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bal
{
    public interface ICarAppointmentServices
    {
        void CustomerMakesAppointment(CarAppointment carAppointment, int userId);

        //List<CarAppointment> ListCustomersCurrentAppointmentStatus(int userid);
        void PostMethodofCustomerMakesAppointment([FromBody] Garage model, int userid);
        List<CarAppointment> ListAllAppointmentsOfCustomer(int userId, bool isAdmin);
        List<CarAppointment> ListAppointmentRequestsforMechanic(int userId);
        void UpdateBookedAppointment([FromBody] CarAppointment model);
        void DeleteAppointment(int id);
        void UpdateAppointmentStatus(int appointmentId, int status);
        void UpdatePaymentStatus(int id);
        List<CarAppointment> ListApprovedAppointments(int userId);

        List<CarAppointment> CustomersServices(int userId);

        List<CarAppointment> ServiceHistory(int userId, bool isAdmin);
        List<CarAppointment> ListServiceHistory(int loggedinUser);
        void GetRatings([FromBody] CarService model);
    }
}
