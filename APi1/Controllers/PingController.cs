using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api1.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api1.Controllers
{
    public class PingController : BasicBaseController
    {

        private readonly ILogger<PingController> _logger;

        public PingController(ILogger<PingController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("ping me");
        }
    }
}
