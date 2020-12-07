using Database.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Services
{
   public interface IRaceVehicleService:IRepository<VehicleRace,int>
    {
       
       VehicleRace AddVehicleToRace(/*Vehicle vehicle*/int Vid,int raceId);
       void RemoveVehicleToRace(int id);
    }
}
