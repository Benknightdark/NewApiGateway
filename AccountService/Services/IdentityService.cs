using System.Net.Http;
using Microsoft.Extensions.Logging;

namespace AccountService.Services
{
    public class IdentityService
    {
        private ILogger<IdentityService> _logger;
        public HttpClient _client { get; }
        public IdentityService(
           ILogger<IdentityService> logger,
           HttpClient client)
        {
            _client = client; ;
            _logger = logger;
        }
    }
}