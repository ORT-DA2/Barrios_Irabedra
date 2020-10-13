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
using Obligatorio.SessionInterface;

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
            services.AddScoped<ICategoryLogic, CategoryLogic>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITouristSpotCategoryLogic, TouristSpotCategoryLogic>();
            services.AddScoped<ITouristSpotCategoryRepository, TouristSpotCategoryRepository>();
            services.AddScoped<IAccommodationLogic, AccommodationLogic>();
            services.AddScoped<IAccommodationRepository, AccommodationRepository>();
            services.AddScoped<ITouristSpotRegionLogic, TouristSpotRegionLogic>();
            services.AddScoped<ITouristSpotRegionRepository, TouristSpotRegionRepository>();
            services.AddScoped<ISessionLogic, SessionLogic>();
            services.AddScoped<IAdminLogic, AdminLogic>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IReservationLogic, ReservationLogic>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
        }
        public void AddDbContextService()
        {
            services.AddDbContext<DbContext, MyContext>();
        }
    }
}
