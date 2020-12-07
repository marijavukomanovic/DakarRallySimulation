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

namespace DakarRallySimulation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RacesController : ControllerBase
    {
        private readonly IRaceService service;
        private readonly IRaceVehicleService _serviceRaceVehicle;
        private readonly IVehicleService _serviceVehicle;
        public RacesController(IRaceService _service, IRaceVehicleService serviceRaceVehicle, IVehicleService serviceVehicle)
        {
            service = _service;
            _serviceRaceVehicle = serviceRaceVehicle;
            _serviceVehicle = serviceVehicle;
        }

        [HttpGet]
        [Route("GetAllRace")]//Izlistavanje svih trka
        public ActionResult<IEnumerable<Race>> GetAllRace()
        {
            var ret = service.GetAll();
            if (ret.Count() == 0)
            {
                return NotFound();
            }
            return ret.ToList();
        }

        [HttpPost("{year}")]
        [Route("AddRace/{year}")]//dodavanje nove trke ,zadaje se godina,moze biti ista godina jer ona ne pretstavlja id
        public ActionResult<Race> AddRace(string year)
        {

            var newRace = new Race(year);
            if (newRace == null)
            {
                return NotFound();
            }
            service.Add(newRace);            
            return newRace;
        }

        [HttpGet]
        [Route("GetRaceStatus/{id}")]
        public ActionResult<RaceBindingModel> GetRaceStatus(int id)//Statistika trke
        {
            RaceBindingModel retRaceBindingModel = new RaceBindingModel();
          int raceStatus = Convert.ToInt32(service.Get(id).status);

            retRaceBindingModel.raceStatus = Helper.vehicleRaceStatusDicInt[raceStatus];
            retRaceBindingModel.numberOfVehicleGrupedByVehiclStatus = service.numberofVehiclebyStatus(id, _serviceRaceVehicle, _serviceVehicle);
            retRaceBindingModel.numberOfVehicleGrupedByVehiclType = service.numberofVehiclebyType(id, _serviceRaceVehicle, _serviceVehicle);

            return retRaceBindingModel;
        }

        [HttpGet("{id}")]
        [Route("StartRace/{id}")]
        public async Task<ActionResult> StartRace(int id)//Pocetak trke zadaje se id trke
        {
            List<Vehicle> runningVehicle = new List<Vehicle>();
            IEnumerable<Vehicle> changseV = new List<Vehicle>();
            runningVehicle = service.GetAllVehiclesWithRaceId(id, _serviceRaceVehicle, _serviceVehicle);
            Race race = service.Get(id);
            race.status = RaceStatus.running;
            
            changseV= await Task.Run(() => service.VehicleStartingRace(runningVehicle));

            foreach (var item in changseV)
            {
                _serviceVehicle.Update(item);
                if (item.DistanceToFinish >= 10000)
                { race.status = RaceStatus.finished; service.Update(race); }
            }

            return Ok();

        }
    }
}
