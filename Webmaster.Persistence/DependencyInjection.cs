using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Webmaster.Application.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Webmaster.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WebmasterDbContext>(options =>
                options.UseLazyLoadingProxies().UseSqlServer(configuration.GetConnectionString("WebmasterDatabase")));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<WebmasterDbContext>());

            return services;
        }
    }
}
