using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Obligatorio.Factory.Factories
{
    public static class ServiceExtension
    {
        public static IServiceCollection EnableAllCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularFrontEndClientApp", builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials());
            });
            return services;
        }
    }
}
