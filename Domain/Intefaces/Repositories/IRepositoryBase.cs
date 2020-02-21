using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories {
    public interface IRepositoryBase<TEntity> where TEntity : class {
        Task<TEntity> AddAsync (TEntity obj);
        IEnumerable<TEntity> AddRange (IEnumerable<TEntity> objs);
        Task<IEnumerable<TEntity>> AddRangeAsync (IEnumerable<TEntity> objs);
        Task<TEntity> GetByIdAsync (int Id);
        Task<IEnumerable<TEntity>> GetAllAsync ();
        IEnumerable<TEntity> Find (Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> FindAsync (Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> UpdateAsync (TEntity obj);
        Task<int> RemoveAsync (int id);
        void Dispose ();
    }
}