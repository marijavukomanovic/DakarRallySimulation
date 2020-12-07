using Database.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.SimulationLogic
{
    public class MalfunctioningProbability
    {
        public string MalfanctionStatistic(Vehicle currentVehicle)
        {
            double lightMF = 0;
            string retVal = "Malfanction Statistic:\n";

            lightMF = currentVehicle.TimeSpentOnFixingRest / currentVehicle.TimeForFixing;
            if (currentVehicle.vehicleState.Equals(VehicleState.HeavyMalfunction))
            { retVal = retVal + "Currently in Heavy Malfunction \n"; }
            else { retVal = retVal + "For now no Heavy Malfunction \n"; }
            return retVal = retVal + "Light Malfunction occured:" + lightMF.ToString();

        }
        public void ProbabilityOfLightMalfanction(List<Vehicle> vehicles)
        {
            foreach (var item in vehicles)
            {
                Random random = new Random();
                item.RandomNumber = random.Next(1, 100);
                if (item.RandomNumber <= item.LightMalfunctionProbability)
                {
                    item.vehicleState = VehicleState.LightMalfunction;
                    item.TimeSpentOnFixingRest += item.TimeForFixing;


                }


            }
        }
        public void ProbabilityOfHeavyMalfanction(List<Vehicle> vehicles)
        {
            foreach (var item in vehicles)
            {
                Random random = new Random();
                item.RandomNumber = random.Next(1, 100);
                if (item.RandomNumber <= item.HeavyMalfunctionProbability)
                {
                    item.vehicleState = VehicleState.HeavyMalfunction;
                    // item.TimeSpentOnFixingRest += item.TimeForFixing;


                }


            }
        }

        public void ProbabilityOfLightMalfanction(Vehicle vehicles)
        {
           
                Random random = new Random();
                vehicles.RandomNumber = random.Next(1, 100);
                if (vehicles.RandomNumber <= vehicles.LightMalfunctionProbability)
                {
                    vehicles.vehicleState = VehicleState.LightMalfunction;
                    vehicles.TimeSpentOnFixingRest += vehicles.TimeForFixing;


                }
            
        }

        public void ProbabilityOfHeavyMalfanction(Vehicle vehicle)
        {

            Random random = new Random();
            vehicle.RandomNumber = random.Next(1, 100);
            if (vehicle.RandomNumber <= vehicle.HeavyMalfunctionProbability)
            {
                vehicle.vehicleState = VehicleState.HeavyMalfunction;
            }

        }
    }
}
