using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Obligatorio.BusinessLogic;
using Obligatorio.BusinessLogic.Logics;
using Obligatorio.BusinessLogicInterface;
using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.DataAccess;
using Obligatorio.DataAccess.Context;
using Obligatorio.DataAccess.Repositories;
using Obligatorio.DataAccessInterface.Interfaces;



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
            services.AddScoped<IRegionLogic, RegionLogic>();
            services.AddScoped<IRegionRepository, RegionRepository>();
        }
        public void AddDbContextService()
        {
            services.AddDbContext<DbContext, MyContext>();
        }
    }
}
