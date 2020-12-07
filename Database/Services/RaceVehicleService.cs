using Microsoft.EntityFrameworkCore;
using Database.Model.Database;
using Database.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Services
{
    public class RaceVehicleService : Repository<VehicleRace, int>, IRaceVehicleService
    {
        public RaceVehicleService(DbContext context) : base(context)
        {

        }

       

        public VehicleRace AddVehicleToRace(/*Vehicle vehicle*/int Vid,int raceId)
        { VehicleRace v = new VehicleRace()
        { RaceId = raceId, VehicleId = Vid /*vehicle.Id*/, Start = DateTime.Now.Year.ToString() };
            Add(v);
            return v; 
           
        }
        public void RemoveVehicleToRace(int id)
        {
            int idRV = -1;
            foreach (var item in GetAll())
            {
                if (item.VehicleId == id)
                {
                    idRV = item.Id;
                    Remove(Get(idRV));
                    break;
                }

            }
            // return Ok();
        }
    }
}
