using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AccountService.Services
{
    public class IdentityService
    {
        private ILogger<IdentityService> _logger;
        private HttpClient _client { get; }
        private IConfiguration _config;
        public IdentityService(
           ILogger<IdentityService> logger,
           HttpClient client,IConfiguration config)
        {
            _logger = logger;
            _client = client;
            _config=config;
        }
        public async Task<string> GetToken()
        {
            var nvc = new List<KeyValuePair<string, string>>();
            nvc.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
            nvc.Add(new KeyValuePair<string, string>("client_id", _config.GetValue<string>("CLIENT")));
            nvc.Add(new KeyValuePair<string, string>("client_secret", _config.GetValue<string>("SECRET")));
            string url=_config.GetValue<string>("IDENTITY_SERVER");
            var req = await _client.PostAsync($"{url}/connect/token", new FormUrlEncodedContent(nvc));
            try
            {
                var data = await req.Content.ReadAsStringAsync();
                return data;
            }
            catch (System.Exception e)
            {
                _logger.LogError(e.Message);
                return string.Empty;
            }
        }
    }
}