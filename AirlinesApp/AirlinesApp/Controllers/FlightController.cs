using AirlinesApp.Db;
using AirlinesApp.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlinesApp.Controllers
{
    public class FlightController: Controller
    {
        private readonly AppDbContext appDbContext;


        public FlightController(AppDbContext appDbContextParam)
        {
            appDbContext = appDbContextParam;
        }


        [HttpGet]
        [Route("airportsListFlight")]
        public IActionResult GetAiports()
        {
            try
            {
                IList<Airport> airports = appDbContext.Airports.Select(a => a).OrderBy(a => a.Name).ToList();

                return new ObjectResult(airports)
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception exc)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("airplanesListFlight")]
        public IActionResult GetAirplanes()
        {
            try
            {
                IList<Airplane> airplanes = appDbContext.Airplanes.Select(a => a).OrderBy(a => a.Name).ToList();

                return new ObjectResult(airplanes)
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception exc)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }



    }
}
