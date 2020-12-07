using Microsoft.EntityFrameworkCore;
using Database.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Database.SimulationLogic;

namespace Database.Services
{
    public class VehicleService : Repository<Vehicle, int>, IVehicleService
    {


        public VehicleService(DbContext context) : base(context)
        {

        }
        public Vehicle EditVehicle(Vehicle vehicle)
        {
            if (Helper.vehicleRuleDic.ContainsKey(vehicle.VehicleModel.ToString()))
            {
                vehicle.Speed = Helper.vehicleRuleDic[vehicle.VehicleModel.ToString()].Speed;
                vehicle.TimeForFixing = Helper.vehicleRuleDic[vehicle.VehicleModel.ToString()].TimeForFixing;
                vehicle.HeavyMalfunctionProbability = Helper.vehicleRuleDic[vehicle.VehicleModel.ToString()].HeavyMalfunctionProbability;
                vehicle.LightMalfunctionProbability = Helper.vehicleRuleDic[vehicle.VehicleModel.ToString()].LightMalfunctionProbability;


            }
            return vehicle;
        }

       
       
        public IEnumerable<Vehicle> GetAllVehicleByType(string type)
        {

            List<Vehicle> retV = new List<Vehicle>();
            foreach (var item in GetAll())
            {
                if (item.VehicleModel.Contains(type)/* && Helper.vehicleRuleDic.ContainsKey(type)*/)
                    retV.Add(item);
            }


            return retV;
        }
        public string GetVehicleStatistic(int id)
        {
            string retval = "";
            Vehicle currentVehicle = Get(id);
            MalfunctioningProbability malfunctioningProbability = new MalfunctioningProbability();
            retval += "Distance til finish:" + currentVehicle.DistanceToFinish.ToString() + "\n" + 
                malfunctioningProbability.MalfanctionStatistic(currentVehicle) +
                "Status:" + currentVehicle.vehicleState.ToString() + "\n";
            if (currentVehicle.vehicleState.Equals(VehicleState.EndGame))
            { retval += "Finished game for" + currentVehicle.CurrentTime; }
            else { retval += "Time in game for now:" + currentVehicle.CurrentTime; }
            return retval;

        }
        public IEnumerable<Vehicle> FindVehicles(string team, string model, string date, string status, bool lenghtPath)
        {
            IEnumerable<Vehicle> ret = new List<Vehicle>();
            ret = GetAll();
            if (team == null) team = " ";
            if (model == null) model = " ";
            if (date == null) date = " ";
            if (status == null) status = " ";


            if (!team.Trim().Equals(""))
            { ret = ret.Where(p => team.Equals(p.TeamName)); }
            if (!model.Trim().Equals("") || model != null)
            { ret = ret.Where(p => model.Equals(p.VehicleModel)); }
            if (!date.Trim().Equals("") || date != null)
            { ret = ret.Where(p => date.Equals(p.VehicleManufacturingDate)); }
            if (!status.Trim().Equals("") || team != null)
            { ret = ret.Where(p => status.Equals(p.vehicleState.ToString())); }
            if (lenghtPath==true)
            {
                ret = ret.OrderBy(c => c.DistanceToFinish);
            }
            return ret;
        }

    }
}
