using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Obligatorio.BusinessLogic.Logics;
using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.DataAccess.Context;
using Obligatorio.DataAccess.Repositories;
using Obligatorio.DataAccessInterface.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Obligatorio.Factory.Factories
{
    public class ServiceFactory
    {
        private readonly IServiceCollection services;
        public ServiceFactory(IServiceCollection services)
        {
            this.services = services;
        }
        public void AddCustomServices()
        {
            services.AddScoped<ITouristSpotRepository, TouristSpotRepository>();
            services.AddScoped<ITouristSpotLogic, TouristSpotLogic>();
        }
        public void AddDbContextService(string connectionString)
        {
            services.AddDbContext<DbContext, MyContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
