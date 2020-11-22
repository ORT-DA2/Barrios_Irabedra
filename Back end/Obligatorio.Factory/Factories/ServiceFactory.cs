﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Obligatorio.BusinessLogic.Logics;
using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.DataAccess.Context;
using Obligatorio.DataAccess.Repositories;
using Obligatorio.DataAccessInterface.Interfaces;
using Obligatorio.ImportLogic.Logics;
using Obligatorio.ImportLogicInterface.Interfaces;
using Obligatorio.SessionInterface;
using System.Runtime.CompilerServices;

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
            services.AddScoped<ISessionLogic, SessionLogic>();
            services.AddScoped<IAdminLogic, AdminLogic>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IReservationLogic, ReservationLogic>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IImportLogic, ImportLogic.Logics.ImportLogic>();
            services.AddScoped<IReportLogic, ReportLogic>();
            services.AddScoped<IReviewLogic, ReviewLogic>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
        }
        public void AddDbContextService()
        {
            services.AddDbContext<DbContext, MyContext>();
        }


    }
}
