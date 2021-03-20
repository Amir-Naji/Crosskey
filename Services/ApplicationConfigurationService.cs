using Microsoft.Extensions.Configuration;
using Services.Interfaces;
using Services.Models;

namespace Services
{
    public class
        ApplicationConfigurationService : IApplicationConfigurationService
    {
        private readonly IConfiguration _configuration;

        public ApplicationConfigurationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ApplicationConfiguration Read()
        {
            var section = _configuration.GetSection("ApplicationSettings");
            return new ApplicationConfiguration
            {
                FilePath = section["FilePath"]
            };
        }
    }
}