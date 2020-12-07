using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database.Model.Database;
using Database.Model.Entity;
using Database.Services;
using DakarRallySimulation.Model;
using AutoMapper;

namespace DakarRallySimulation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
       private readonly AppDBContext _context;
        private readonly IVehicleService service;
       

        public VehiclesController(AppDBContext context, IVehicleService vehicleService)
        {
            _context = context;
            service = vehicleService;
           
        }

        // GET: api/Vehicles
        [HttpGet]
        [Route("GetVehicles")]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicles()//vrati sva vozlia
        {
            return await _context.Vehicles.ToListAsync();
        }
       
        [HttpPost]
        [Route("AddVehicle/{team}/{model}/{date}")]//dodaj novo vozilo
        public ActionResult<Vehicle> AddVehicle(string team, string model, string date)
        {
            model = model.Trim();
            Vehicle newVehicle = new Vehicle(team, model, date);
            service.Add(newVehicle);
            return Ok(newVehicle);
        }
        [HttpPut]
        [Route("UpdateVehicle/{id}/{team}/{model}/{date}")]
        public ActionResult<Vehicle> UpdateVehicle(int id, string team, string model, string date)
        {
            Vehicle editVehicle = service.Get(id);
            editVehicle.TeamName = team;
            if (!editVehicle.VehicleModel.Equals(model))
            { editVehicle.VehicleModel = model;
                service.EditVehicle(editVehicle);
            }
            editVehicle.VehicleManufacturingDate = date;
            
            service.Update(editVehicle);

            return Ok(editVehicle);
        }



        [HttpGet("{id}")]
        [Route("GetVehicle/{id}")]
        public async Task<ActionResult<Vehicle>> GetVehicle(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return vehicle;
        }


        // GET: api/Vehicles
        [HttpGet("{type}")]
        [Route("GetAllVehiclesByType/{type}")]//Vrati sa odredjenim tipom
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetAllVehiclesByType(string type)
        {
            return await Task.Run(() => service.GetAllVehicleByType(type).ToList());
        }


        [HttpGet]
        [Route("GetVehicleStatistic/{id}")]
        public ActionResult<string> GetVehicleStatistic(int id)
        {
            return  service.GetVehicleStatistic(id).ToString();
        }

        [HttpGet("{team}/{model}/{date}/{status}/{lenghtPath}")]
        [Route("FindVehicle/{team}/{model}/{date}/{status}/{lenghtPath}")]
        public async Task <ActionResult<IEnumerable<Vehicle>>> FindVehicle(string team, string model, string date, string status, bool lenghtPath)
        {
           
            return await Task.Run(() => service.FindVehicles(team,model,date,status,lenghtPath).ToList());
        }
}
}
