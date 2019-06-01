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



        [HttpPost]
        [Route("saveFlight")]
        public IActionResult Save([FromBody]FlightDTO model)
        {   
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

            Airplane airplane = appDbContext.Airplanes.Select(a => a).Where(a => a.Id == model.Airplane).FirstOrDefault();
            Airport ato = appDbContext.Airports.Select(a => a).Where(a => a.Id == model.ToAirport).FirstOrDefault();
            Airport afrom = appDbContext.Airports.Select(a => a).Where(a => a.Id == model.FromAirport).FirstOrDefault();

            Flight flight = new Flight { Duration = model.Duration, Name = model.Name, Airplane = airplane, ToAirport = ato, FromAirport = afrom };
            appDbContext.Flights.Add(flight);
            appDbContext.SaveChanges();

            return Ok();  
        }
    }








}

