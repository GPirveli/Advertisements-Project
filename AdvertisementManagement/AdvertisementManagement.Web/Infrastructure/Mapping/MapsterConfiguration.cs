using AdvertisementManagement.Domain.POCO;
using AdvertisementManagement.Service.Models;
using AdvertisementManagement.Web.Models.DTOs;
using AdvertisementManagement.Web.Models.Requests;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisementManagement.Web.Infrastructure.Mapping
{
    public static class MapsterConfiguration
    {
        public static void RegisterMaps(this IServiceCollection service)
        {
            TypeAdapterConfig<AdvertisementServiceModel, Advertisement>.NewConfig().TwoWays();
            TypeAdapterConfig<AdvertisementServiceModel, AdvertisementDTO>.NewConfig();
            TypeAdapterConfig<CreateAdvertisementRequest, AdvertisementServiceModel>.NewConfig();
            TypeAdapterConfig<UpdateAdvertisementRequest, AdvertisementServiceModel>.NewConfig();
        }
    }
}
