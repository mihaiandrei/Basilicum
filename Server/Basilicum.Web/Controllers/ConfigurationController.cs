namespace Basilicum.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using System.Collections.Generic;

    [Route("config")]
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public ConfigurationController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        [Route("")]
        public Dictionary<string, string> GetConfiguration()
        {
            return new Dictionary<string, string> { { "apiBaseAddress", configuration["apiBaseAddress"] } };
        }
    }
}
