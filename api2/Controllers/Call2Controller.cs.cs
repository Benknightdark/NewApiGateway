using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api2.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api2.Controllers
{

    public class Call2Controller : BasicBaseController
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<Call2Controller> _logger;

        public Call2Controller(ILogger<Call2Controller> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("come from api2");
        }
    }
}
