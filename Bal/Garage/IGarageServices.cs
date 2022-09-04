using Dal.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bal
{
    public interface IGarageServices
    {
        List<Garage> ListOfAllGaragesforMechanic(int userId);
        List<Garage> ListAllGaragesByParameters(int serviceCharge, string city);
        List<Garage> ListAllAvailableGaragesforCustomer(bool isCustomer, bool isAdmin);
        Garage GetServicesDetailsModal(int Id);
        void UpdatingGarageDetails([FromBody] Garage model);

        void DeleteGarage(int i);
        void DeleteGarageImage(int id);
        Garage GarageByGarageId(int garageid);

        void CreatesGarages(Garage garage, int userId);
    }
}
