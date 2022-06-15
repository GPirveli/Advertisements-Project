using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementManagement.Data
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(int key);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        IQueryable<T> Table { get; }
    }
}
