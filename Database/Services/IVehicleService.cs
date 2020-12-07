using Database.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Services
{
    public interface IVehicleService : IRepository<Vehicle, int>
    {

        IEnumerable<Vehicle> GetAllVehicleByType(string type);
        String GetVehicleStatistic(int id);
        IEnumerable<Vehicle> FindVehicles(string team, string model, string date, string status, bool lenghtPath);

        Vehicle EditVehicle(Vehicle vehicle);
      
       

    }
}
