using Beslogic.Pratice.API.Context;
using Beslogic.Pratice.API.Models;
using Beslogic.Pratice.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Beslogic.Pratice.API.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class AircraftsController : ControllerBase
    {
        private readonly IAircraftService _aircraftService;
        public AircraftsController(IAircraftService aircraftService)
        {
            _aircraftService = aircraftService;
        }

        [HttpGet]
        public ActionResult<List<Aircraft>> GetAircrafts()
        {
            return Ok(_aircraftService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Aircraft>>> GetAircrafts(int id)
        {
            return Ok(await _aircraftService.GetById(id));
        }


        [HttpPost]
        public async Task<ActionResult<Aircraft>> AddAircrafts(Aircraft aircraft) 
        {
            return Ok(await _aircraftService.Add(aircraft));

        }

        [HttpPut("{id}")]
        public async Task<Aircraft> UpdateAircrafts(int id, Aircraft aircraft)
        {
            return await _aircraftService.Update(id, aircraft);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteAircraft(int id)
        {
            await _aircraftService.Delete(id);
            return NoContent();
        }
    }
}
