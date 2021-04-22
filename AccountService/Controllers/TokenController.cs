using System.Threading.Tasks;
using AccountService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AccountService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {


        private readonly ILogger<TokenController> _logger;
        private IdentityService _identityService;
        public TokenController(ILogger<TokenController> logger,IdentityService identityService)
        {
            _logger = logger;
            _identityService=identityService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Token=await _identityService.GetToken();
            return Ok(Token);
        }
    }
}
