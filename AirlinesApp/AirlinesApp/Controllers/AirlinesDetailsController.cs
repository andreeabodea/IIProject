using System;
using System.Collections.Generic;
using System.Linq;
using AirlinesApp.Db;
using AirlinesApp.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace AirlinesApp.Controllers
{
    public class AirlinesDetailsController : Controller
    {
        private readonly AppDbContext appDbContext;

        public AirlinesDetailsController(AppDbContext appDbContextParam)
        {
            appDbContext = appDbContextParam;
        }

        [HttpGet]
        [Route("airlines")]
        [Authorize(Policy = "Admin")]
        public IActionResult GetAirlines() 
        {
            try
            {
                IList<Airline> airlines = appDbContext.Airlines.Select(al => al).OrderBy(al => al.Id).ToList();

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

    }
}

