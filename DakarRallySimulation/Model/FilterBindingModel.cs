using Database.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DakarRallySimulation.Model
{
    public class FilterBindingModel
    {
        
        public String TeamName { get; set; }
        public String VehicleModel { get; set; }
        public string VehicleManufacturingDate { get; set; }

        public VehicleState vehicleState { get; set; }
        public double Distance { get; set; }
    }
}
