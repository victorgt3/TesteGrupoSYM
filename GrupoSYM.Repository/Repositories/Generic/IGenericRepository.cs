﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GrupoSYM.Repository.Repositories.Generic
{
    public interface IGenericRepository<T> : IDisposable where T : class
    {
        Task<T> GetAsync(Expression<Func<T, bool>> where);
        Task<T> GetByIdAsync(object id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
        Task<int> SaveChangesAsync();
    }
}
