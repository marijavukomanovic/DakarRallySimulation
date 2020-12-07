using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Database.Model.Entity;
using System.Linq;
using System.Threading.Tasks;
using Database.SimulationLogic;

namespace Database.Services
{
    public class RaceService : Repository<Race, int>, IRaceService
    {

        public RaceService(DbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Vehicle>> VehicleStartingRace(List<Vehicle> runningVehicle)
        {
            List<Vehicle> newV = new List<Vehicle>();
            List<Task<Vehicle>> task = new List<Task<Vehicle>>();
            DrivingSimulation DrivingSimulation = new DrivingSimulation();
            foreach (var item in runningVehicle)
            {
                if (item != null)
                {
                    item.vehicleState = VehicleState.Driving;
                    task.Add(Task.Run(() => DrivingSimulation.DrivingRace(item)));
                }
            }
            var results = await Task.WhenAll(task);
            return newV;
        }
        public Race CurrentRace()
        {
            Race r = new Race();

            foreach (var item in GetAll())
            {
                if (item != null && !(item.status.Equals(RaceStatus.finished)))
                {
                    if (item.Start.Equals(DateTime.Now.Year))
                    { r = item; }

                }

            }
            return r;
        }

        public List<Vehicle> GetAllVehiclesWithRaceId(int id, IRaceVehicleService _serviceRaceVehicle, IVehicleService _serviceVehicle)
        {
            List<Vehicle> allVehiclesWithRaceId = new List<Vehicle>();
            if (_serviceRaceVehicle.GetAll().Count() != 0)
                foreach (var item in _serviceRaceVehicle.GetAll())
                {
                    if (item.RaceId == id)
                    {
                        allVehiclesWithRaceId.Add(_serviceVehicle.Get(item.VehicleId));
                    }

                }

            return allVehiclesWithRaceId;

        }

        public int[] numberofVehiclebyStatus(int id, IRaceVehicleService _serviceRaceVehicle, IVehicleService _serviceVehicle)
        {
            List<Vehicle> allVehiclesWithRaceId = new List<Vehicle>();
            int[] numberofVehiclebyStatus = new int[5];
            allVehiclesWithRaceId = GetAllVehiclesWithRaceId(id, _serviceRaceVehicle, _serviceVehicle);
            if (allVehiclesWithRaceId.Count != 0)
                foreach (var item in allVehiclesWithRaceId)
                {
                    if (item != null)
                    {
                        if (Helper.vehicleStateDic.ContainsKey(item.vehicleState.ToString()))
                        { numberofVehiclebyStatus[Helper.vehicleStateDic[item.vehicleState.ToString()]]++; }
                    }


                }
            return numberofVehiclebyStatus;
        }

        public int[] numberofVehiclebyType(int id, IRaceVehicleService _serviceRaceVehicle, IVehicleService _serviceVehicle)
        {
            List<Vehicle> allVehiclesWithRaceId = new List<Vehicle>();
            int[] numberofVehiclebyType = new int[5];
            allVehiclesWithRaceId = GetAllVehiclesWithRaceId(id, _serviceRaceVehicle, _serviceVehicle);
            if (allVehiclesWithRaceId.Count != 0)
                foreach (var item in allVehiclesWithRaceId)
                {
                    if (item != null)
                    {
                        if (Helper.vehicleRuleDic.ContainsKey(item.VehicleModel.ToString()))
                        { numberofVehiclebyType[Helper.vehicleRuleDic[item.VehicleModel.ToString()].typeOfVehicles]++; }
                    }
                }
            return numberofVehiclebyType;
        }


    }
}
