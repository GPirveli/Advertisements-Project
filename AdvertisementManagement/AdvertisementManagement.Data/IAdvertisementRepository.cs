using AdvertisementManagement.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementManagement.Data
{
    public interface IAdvertisementRepository : IBaseRepository<Advertisement>
    {
        Task<string> GetTitleAsync(int id);
        Task<string> GetDescriptionAsync(int id);
        Task<string> GetImageAsync(int id);
        Task<string> GetPhoneNumberAsync(int id);
        Task<List<Advertisement>> GetByTitleAsync(string title);
    }
}
