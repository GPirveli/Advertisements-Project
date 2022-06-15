using AdvertisementManagement.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementManagement.Service.Abstractions
{
    public interface IAdvertisementService
    {
        Task<List<AdvertisementServiceModel>> GetAllAsync();
        Task<AdvertisementServiceModel> GetAsync(int id);
        Task<List<AdvertisementServiceModel>> GetByTitleAsync(string title);
        Task<string> GetTitleAsync(int id);
        Task<string> GetDescriptionAsync(int id);
        Task<string> GetImageAsync(int id);
        Task<string> GetPhoneNumberAsync(int id);
        Task CreateAsync(AdvertisementServiceModel advertisement);
        Task UpdateAsync(AdvertisementServiceModel advertisement);
    }
}
