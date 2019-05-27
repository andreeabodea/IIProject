using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlinesApp.Controllers
{
    public class FlightQueryParams
    {

        private readonly HttpContext httpContext;

        internal int Airline { get; set; }

        internal int Airport { get; set; }


        internal FlightQueryParams(HttpContext httpContextParam)
        {
            httpContext = httpContextParam;
            Airline = GetIntSafeFromQuery("airline");
            Airport = GetIntSafeFromQuery("airport");
        }

        private int GetIntSafeFromQuery(string paramName)
        {
            string paramValue = httpContext.Request.Query[paramName];
            int res;
            return Int32.TryParse(paramValue, out res) ? res : -1;
        }


    }
}


