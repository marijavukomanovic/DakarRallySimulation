using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
//using DakarRally.Models.Entity;

namespace Database.Model.Entity
{
    public class Vehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String TeamName { get; set; }
        public String VehicleModel { get; set; }
        public string VehicleManufacturingDate { get; set; }
       
        public VehicleState vehicleState { get; set; }
        public TypeOfVehicles TypeOfVehicles { get; set; }     

        public Double Speed { get; set; }
        public int TimeForFixing { get; set; }
        public Double HeavyMalfunctionProbability { get; set; }
        public Double LightMalfunctionProbability { get; set; }
        public Double RandomNumber { get; set; }

        public Double CurrentTime { get; set; }
        public Double DistanceToFinish { get; set; }
        public double TimeSpentOnFixingRest { get; set; }
     //treba da se doda vreme odmora public Double RestTime{get;set}

        public Vehicle() { }
        public Vehicle(String team_name, String vehicle_model, string vehicle_manufacturing_date)
        {
            TeamName = team_name;
            VehicleModel = vehicle_model;
            VehicleManufacturingDate = vehicle_manufacturing_date;
            vehicleState = VehicleState.Pending;
            CurrentTime = 0;
            DistanceToFinish = 10000;
            RandomNumber = 0;
            TimeSpentOnFixingRest = 0;
            if (Helper.vehicleRuleDic.ContainsKey(vehicle_model))
            {
                Speed = Helper.vehicleRuleDic[vehicle_model].Speed;
                TimeForFixing = Helper.vehicleRuleDic[vehicle_model].TimeForFixing;
                HeavyMalfunctionProbability = Helper.vehicleRuleDic[vehicle_model].HeavyMalfunctionProbability;
                LightMalfunctionProbability = Helper.vehicleRuleDic[vehicle_model].LightMalfunctionProbability;
                
            }
            else
            {
                Speed = 0;
                TimeForFixing = 0;
                HeavyMalfunctionProbability = 0;
                LightMalfunctionProbability = 0;
               
               
            }
        }
        
        //public override string ToString() 
        //{
        //    return "Id :" + Id + "TramName :" + TeamName + "VehicleModel :" +
        //        VehicleModel + "Date :" + VehicleManufacturingDate +
        //        "State :" + vehicleState.ToString()+"\n"
        //        + "Speed :" + Speed.ToString() 
        //        + "Time For Fixing :" + TimeForFixing.ToString() +"\n"
        //        + "Heavy Malfunction Probability :" 
        //        + HeavyMalfunctionProbability.ToString()+"\n"
        //        + "Light Malfunction Probability:" 
        //        + LightMalfunctionProbability.ToString();
        //}
       


    }
}

