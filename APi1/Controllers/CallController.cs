﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api1.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api1.Controllers
{
    public class CallController : AuthBaseController
    {
      
        private readonly ILogger<CallController> _logger;

        public CallController(ILogger<CallController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("come from api1");
        }
    }
}
