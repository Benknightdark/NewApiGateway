using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api1.Controllers.Base
{
    [Route("api/[controller]")]
    public class BasicBaseController : BaseController
    {


        public BasicBaseController()
        {
        }


    }
}
