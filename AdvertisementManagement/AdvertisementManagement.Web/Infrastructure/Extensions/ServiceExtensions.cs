using AdvertisementManagement.Service.Abstractions;
using AdvertisementManagement.Service.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisementManagement.Web.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAdvertisementService, AdvertisementService>();
        }
    }
}
