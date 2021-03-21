using System;
using Mathematics;
using Mathematics.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mortgage;
using Mortgage.Interfaces;
using Repository;
using Repository.Interfaces;
using Services;
using Services.Interfaces;

namespace Crosskey
{
    public class DependencyInjection
    {
        private readonly IApplicationConfigurationService _config;
        private readonly IServiceCollection _services;


        public DependencyInjection() : this(new ServiceCollection())
        {
        }

        public DependencyInjection(IServiceCollection services) : this(services,
            new ApplicationConfigurationService(new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true).Build()))
        {
        }

        public DependencyInjection(IServiceCollection services,
            IConfiguration config) : this(services,
            new ApplicationConfigurationService(config))
        {
        }

        private DependencyInjection(IServiceCollection services,
            IApplicationConfigurationService config)
        {
            _services = services;
            _config = config;
        }

        public IServiceCollection ConfigureServices()
        {
            _services.AddTransient<IArithmetic, Arithmetic>();
            _services.AddTransient<IPlan, Plan>();
            _services.AddTransient<ICustomerRepository, CustomerRepository>(
                CustomerRepositoryResolve());

            _services.AddTransient<ILoanService, LoanService>();
            _services
                .AddTransient<IApplicationConfigurationService,
                    ApplicationConfigurationService>();

            return _services;
        }

        private Func<IServiceProvider, CustomerRepository>
            CustomerRepositoryResolve()
        {
            return _ => new CustomerRepository(_config.Read().FilePath);
        }
    }
}