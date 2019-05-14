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
    public class AirlinesController : Controller
    {
        private readonly AppDbContext appDbContext;

        public AirlinesController(AppDbContext appDbContextParam)
        {
            appDbContext = appDbContextParam;
        }

        [HttpGet]
        [Route("airlines")]
        public IActionResult GetConfiguration()
        {
            //Logger.Enter();

            try
            {
                IList<Airline> airlines = appDbContext.Airlines.Select(al => al).OrderBy(al => al.Name).ToList();

                return new ObjectResult(airlines)
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception exc)
            {
                //Logger.Exception(exc, "Error occurred during retrieving configurations.");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}

