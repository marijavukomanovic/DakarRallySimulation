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

namespace DakarRallySimulation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleRacesController : ControllerBase
    {       //ova tabela sluzi kao spoj tabela race i vehicle da bi se znalo koje vozilo pripada kojoj trci
        private readonly IRaceVehicleService service;
        private readonly IRaceService raceService;
        public VehicleRacesController( IRaceVehicleService _service,IRaceService race)
        {           
            service = _service;
            raceService = race;
        }
        [HttpPost("{id}")]
        [Route("AddVehicleToRace/{id}")]
        public async Task<ActionResult<VehicleRace>> AddVehicleToRace(int id)//adding Vehicle to the race(to raceVehicle tabel)
        {
            Race race = await Task.Run(() => raceService.CurrentRace());
            return service.AddVehicleToRace(id, race.Id);

        }
        [HttpDelete("{id}")]
        [Route("RemoveVehicleFromRace/{id}")]//Removing Vehicle from the race(raceVehicle tabel)-argument is Vehicle id
        public ActionResult RemoveVehicleFromRace(int id)
        {
            service.RemoveVehicleToRace(id);
            return Ok();
        }









    }
}
