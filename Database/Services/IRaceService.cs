using Database.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Database.Services
{
    public interface IRaceService : IRepository<Race, int>
    {
        // Race AddRace(string year);
        List<Vehicle> GetAllVehiclesWithRaceId(int id, IRaceVehicleService _serviceRaceVehicle, IVehicleService _serviceVehicle);
        int[] numberofVehiclebyStatus(int id, IRaceVehicleService _serviceRaceVehicle, IVehicleService _serviceVehicle);
        int[] numberofVehiclebyType(int id, IRaceVehicleService _serviceRaceVehicle, IVehicleService _serviceVehicle);
        Task<IEnumerable<Vehicle>> VehicleStartingRace(List<Vehicle> runningVehicle);
        Race CurrentRace();




    }
}
