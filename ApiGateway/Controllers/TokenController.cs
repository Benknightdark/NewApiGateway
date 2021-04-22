using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace ApiGateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : ControllerBase
    {
    

        private readonly ILogger<TokenController> _logger;
        private IConfiguration _configuration;
        public TokenController(ILogger<TokenController> logger,IConfiguration configuration)
        {
            _logger = logger;
            _configuration=configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            #region 加入jwt claims 角色授權


            #endregion 加入jwt claims 角色授權

            var token = new JwtSecurityToken(
                // issuer: _configuration.GetValue<string>("Tokens:ValidIssuer"),
                // audience: _configuration.GetValue<string>("Tokens:ValidAudience"),
                expires: DateTime.Now.AddDays(365),
                // claims: claims,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWTSecretKey"))),
                    SecurityAlgorithms.HmacSha256)
            );
            // token.Payload.Add("UserInfo", model);
            var SecurityToken = (new JwtSecurityTokenHandler().WriteToken(token));
            return Ok(SecurityToken);
        }
    }
}
