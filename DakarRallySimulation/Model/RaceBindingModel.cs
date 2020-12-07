using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DakarRallySimulation.Model
{
    public class RaceBindingModel
    {
        public string raceStatus { get; set; }
        public int[] numberOfVehicleGrupedByVehiclStatus { get; set; }
        public int[] numberOfVehicleGrupedByVehiclType { get; set; }
        public RaceBindingModel()
        {
            numberOfVehicleGrupedByVehiclStatus = new int[5];
            numberOfVehicleGrupedByVehiclType = new int[5];
        }
    }
}
