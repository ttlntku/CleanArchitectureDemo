﻿using Core.Entities.Base;
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
        public Repository(DataContext employeeContext)
        {
            _dataContext = employeeContext;
        }
        public async Task<T> AddAsync(T entity, string createdBy, string updatedBy)
        {
            entity.CreatedBy = createdBy;
            entity.CreatedAt = CustomUtilities.CustomDatetimeConvert(DateTime.Now);
            entity.UpdatedBy = updatedBy;
            entity.UpdatedAt = CustomUtilities.CustomDatetimeConvert(DateTime.Now);
            await _dataContext.Set<T>().AddAsync(entity);
            await _dataContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dataContext.Set<T>().Remove(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dataContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dataContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(s => s.Id.Equals(id));
        }

        public async Task<T> UpdateAsync(T entity, string updatedBy)
        {
            entity.UpdatedBy = updatedBy;
            entity.UpdatedAt = CustomUtilities.CustomDatetimeConvert(DateTime.Now);
            _dataContext.Set<T>().Update(entity);
            await _dataContext.SaveChangesAsync();
            return entity;
        }
    }
}
