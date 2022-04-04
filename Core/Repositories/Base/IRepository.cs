using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity, string createdBy, string updatedBy);
        Task<T> UpdateAsync(T entity, string updatedBy);
        Task DeleteAsync(T entity);
    }
}
