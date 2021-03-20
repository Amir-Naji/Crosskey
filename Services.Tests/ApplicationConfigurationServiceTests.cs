using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Services.Interfaces;

namespace Services.Tests
{
    public class ApplicationConfigurationServiceTests
    {
        private const string FilePath = "prospects.txt";
        private readonly IApplicationConfigurationService _config;

        public ApplicationConfigurationServiceTests()
        {
            _config = new ApplicationConfigurationService(
                new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", true, true).Build());
        }

        [Test]
        public void Read_NoInput_ReturnsConfigurationValues()
        {
            var result = _config.Read();
            Assert.AreEqual(FilePath, result.FilePath);
        }
    }
}