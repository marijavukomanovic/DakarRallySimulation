using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Model.Entity
{
    public enum TypeOfVehicles
    {
       
        Truck,        
        SportsCar,
        TerrainCar,
        SportMotorcycle,
        CrossMotorcycle

    }
    public class VehicleRule
    {
        public Double Speed { get; set; }
        public int TimeForFixing { get; set; }
        public Double HeavyMalfunctionProbability { get; set; }
        public Double LightMalfunctionProbability { get; set; }
        public int typeOfVehicles { get;
            set;
        }
        public VehicleRule() { }
        public VehicleRule(double Sp,int time,double HMP,double LMP,int ty) 
        { 
            Speed = Sp;
            TimeForFixing = time;
            HeavyMalfunctionProbability = HMP;
            LightMalfunctionProbability = LMP;
            typeOfVehicles = ty;
        }
    }
    public class Helper
    {
     public static readonly Dictionary<string, VehicleRule> vehicleRuleDic = new Dictionary<string, VehicleRule>()
    {{TypeOfVehicles.Truck.ToString(),new VehicleRule(80,7,4,6,0) },
    {TypeOfVehicles.SportsCar.ToString(),new VehicleRule(140,5,2,12,1) },
    {TypeOfVehicles.TerrainCar.ToString(),new VehicleRule(100,5,1,3,2) },
    {TypeOfVehicles.CrossMotorcycle.ToString(),new VehicleRule(85,3,2,3,3) },
    {TypeOfVehicles.SportMotorcycle.ToString(),new VehicleRule(130,3,10,18,4) }};

        public static readonly Dictionary<string, int> vehicleStateDic = new Dictionary<string, int>()
    {{VehicleState.Pending.ToString(),0},
    {VehicleState.Driving.ToString(),1 },
    {VehicleState.HeavyMalfunction.ToString(),2 },
    {VehicleState.LightMalfunction.ToString(),3  },
    {VehicleState.EndGame.ToString(),4 } };


        public static readonly Dictionary<string, int> vehicleRaceStatusDic = new Dictionary<string, int>()
    {{RaceStatus.pending.ToString(),0},
    {RaceStatus.running.ToString(),1 },
    {RaceStatus.finished.ToString(),2 }, };

        public static readonly Dictionary<int, string> vehicleRaceStatusDicInt = new Dictionary<int, string>()
    {{0,RaceStatus.pending.ToString()},
    {1,RaceStatus.running.ToString() },
    {2,RaceStatus.finished.ToString() }, };
    }
   
}



