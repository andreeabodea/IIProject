using AirlinesApp.Db;
using AirlinesApp.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AirlinesApp.Controllers
{
    public class HistoryController : Controller
    {
        private readonly AppDbContext appDbContext;

        private FlightQueryParams flightQueryParamas; 

        public HistoryController(AppDbContext appDbContextParam)
        {
            appDbContext = appDbContextParam;
        }

        [HttpGet]
        [Route("airportsList")]
        public IActionResult GetAiports()
        {
            try
            {
                IList<Airport> airports = appDbContext.Airports.Select(a => a).OrderBy(a =>a.Name).ToList();

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
        [Route("airlinesList")]
        public IActionResult GetAirlines()
        {
            try
            {
                IList<Airline> airlines = appDbContext.Airlines.Select(a => a).OrderBy(a => a.Name).ToList();

                return new ObjectResult(airlines)
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
        [Route("historyList")]
        public IActionResult GetFlights()
        {
            try
            {
                flightQueryParamas = new FlightQueryParams(HttpContext);

                IList<Flight> flights = appDbContext.Flights.Select(f => f)
                    .Include( f=> f.Airplane)
                    .Include( f=> f.ToAirport)
                    .Include ( f=> f.FromAirport)
                    .Where(f => f.Airplane.Airline.Id == flightQueryParamas.Airline && f.FromAirport.Id == flightQueryParamas.Airport)
                    .OrderBy(f => f.Name).ToList();

                return new ObjectResult(flights)
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

