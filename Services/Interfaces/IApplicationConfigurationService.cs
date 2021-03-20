using Services.Models;

namespace Services.Interfaces
{
    public interface IApplicationConfigurationService
    {
        ApplicationConfiguration Read();
    }
}