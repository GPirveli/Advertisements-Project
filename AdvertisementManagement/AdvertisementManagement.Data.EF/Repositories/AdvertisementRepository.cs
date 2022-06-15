using AdvertisementManagement.Domain.POCO;
using AdvertisementManagement.PersistanceDB.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementManagement.Data.EF.Repositories
{
    public class AdvertisementRepository : BaseRepository<Advertisement>, IAdvertisementRepository
    {
        public AdvertisementRepository(AdvertisementManagementContext context) : base(context)
        {

        }

        public async Task<string> GetDescriptionAsync(int id)
        {
            var advertisement = await GetAsync(id);
            return advertisement.Description;
        }

        public async Task<string> GetPhoneNumberAsync(int id)
        {
            var advertisement = await GetAsync(id);
            return advertisement.PhoneNumber;
        }

        public async Task<string> GetImageAsync(int id)
        {
            var advertisement = await GetAsync(id);
            return advertisement.Image;
        }

        public async Task<string> GetTitleAsync(int id)
        {
            var advertisement = await GetAsync(id);
            return advertisement.Title;
        }

        public async Task<List<Advertisement>> GetByTitleAsync(string title)
        {
            return await _dbSet.Where(x => x.Title.ToLower().Contains(title.ToLower())).ToListAsync();
        }
    }
}
