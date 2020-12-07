using Database.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Database.SimulationLogic
{
  public  class DrivingSimulation
    {
        MalfunctioningProbability malfunctioningProbability = new MalfunctioningProbability();
        public async Task<Vehicle> DrivingRace(Vehicle vehicle)
        {
            var st = DateTime.Now;//System.Diagnostics.Stopwatch.StartNew().ElapsedMilliseconds;
           
            do
            {
                if (vehicle.vehicleState.Equals(VehicleState.Driving))
                {
                 await Task.Run(()=> calculating(vehicle,st));
                }
                else{ break; }

            } while (vehicle.DistanceToFinish < 10000);
            if (vehicle.DistanceToFinish >= 10000 || vehicle.vehicleState.Equals(VehicleState.HeavyMalfunction))
            {
                if(!vehicle.vehicleState.Equals(VehicleState.HeavyMalfunction))
                vehicle.vehicleState = VehicleState.EndGame;

            }
            return vehicle;
        }
        public void calculating(Vehicle vehicle,DateTime st)
        {
            TimeSpan ts = DateTime.Now - st;
            vehicle.CurrentTime += ts.Seconds - vehicle.TimeForFixing;
            vehicle.DistanceToFinish = vehicle.Speed * vehicle.CurrentTime * 1000;// u sekundama umesto u satima,takodje pomnozeno cisto radi kraceg rada

            malfunctioningProbability.ProbabilityOfHeavyMalfanction(vehicle);
            malfunctioningProbability.ProbabilityOfLightMalfanction(vehicle);
        }
    }
}
