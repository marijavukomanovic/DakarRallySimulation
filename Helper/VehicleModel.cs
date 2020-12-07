using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
 public    class VehicleModels
    {
        public int Id { get; set; }
        public String TeamName { get; set; }
        public String VehicleModel { get; set; }
        public string VehicleManufacturingDate { get; set; }

        public string vehicleState { get; set; }
        public string TypeOfVehicles { get; set; }

        public Double Speed { get; set; }
        public int TimeForFixing { get; set; }
        public Double HeavyMalfunctionProbability { get; set; }
        public Double LightMalfunctionProbability { get; set; }
        public Double RandomNumber { get; set; }

        public Double CurrentTime { get; set; }
        public Double DistanceToFinish { get; set; }
        public double TimeSpentOnFixingRest { get; set; }
    }
}
