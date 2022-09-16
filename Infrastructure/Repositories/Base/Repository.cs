using Core.Entities.Base;
using Core.Helpers;
using Core.Repositories.Base;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DataContext _dataContext;
        protected readonly DbSet<T> DbSet;

        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;         
            DbSet = dataContext.Set<T>();
        }
        public async Task<T> AddAsync(T entity, string createdBy, string updatedBy)
        {
            entity.CreatedBy = createdBy;
            entity.CreatedAt = CustomUtilities.CustomDatetimeConvert(DateTime.Now);
            entity.UpdatedBy = updatedBy;
            entity.UpdatedAt = CustomUtilities.CustomDatetimeConvert(DateTime.Now);
            await DbSet.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            DbSet.Remove(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(s => s.Id.Equals(id));
        }

        public async Task<T> UpdateAsync(T entity, string updatedBy)
        {
            entity.UpdatedBy = updatedBy;
            entity.UpdatedAt = CustomUtilities.CustomDatetimeConvert(DateTime.Now);
            DbSet.Update(entity);
            await _dataContext.SaveChangesAsync();
            return entity;
        }
    }
}
