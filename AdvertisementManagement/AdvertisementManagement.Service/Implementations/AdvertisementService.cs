using AdvertisementManagement.Data;
using AdvertisementManagement.Domain.POCO;
using AdvertisementManagement.Service.Abstractions;
using AdvertisementManagement.Service.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementManagement.Service.Implementations
{
    public class AdvertisementService : IAdvertisementService
    {
        private IAdvertisementRepository _repo;

        public AdvertisementService(IAdvertisementRepository repo)
        {
            _repo = repo;
        }

        public async Task CreateAsync(AdvertisementServiceModel advertisement)
        {
           await _repo.CreateAsync(advertisement.Adapt<Advertisement>());
        }

        public async Task<List<AdvertisementServiceModel>> GetAllAsync()
        {
            var advertisements = await _repo.GetAllAsync();
            return advertisements.Adapt<List<AdvertisementServiceModel>>();
        }

        public async Task<AdvertisementServiceModel> GetAsync(int id)
        {
            var advertisement = await _repo.GetAsync(id);
            return advertisement.Adapt<AdvertisementServiceModel>();
        }

        public async Task<List<AdvertisementServiceModel>> GetByTitleAsync(string title)
        {
            var advertisement = await _repo.GetByTitleAsync(title);
            return advertisement.Adapt<List<AdvertisementServiceModel>>();
        }

        public async Task<string> GetDescriptionAsync(int id)
        {
            return await _repo.GetDescriptionAsync(id);
        }

        public async Task<string> GetImageAsync(int id)
        {
            return await _repo.GetImageAsync(id);
        }

        public async Task<string> GetPhoneNumberAsync(int id)
        {
            return await _repo.GetPhoneNumberAsync(id);
        }

        public async Task<string> GetTitleAsync(int id)
        {
            return await _repo.GetTitleAsync(id);
        }

        public async Task UpdateAsync(AdvertisementServiceModel advertisement)
        {
            var advertisementToUpdate = advertisement.Adapt<Advertisement>();
            await _repo.UpdateAsync(advertisementToUpdate);
        }
    }
}
