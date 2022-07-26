using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Udemy.Adversitement.Common.Enums;
using Udemy.Advertisement.Entities;

namespace Udemy.AdvertisementApp.DataAccess.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();

        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        
        Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> selector,
            OrderByType type = OrderByType.DESC);

        Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> selector,
            OrderByType type = OrderByType.DESC);

        Task<T> FindAsync(object id);

        Task CreateAsync(T entity);

        void Update(T entity, T unchanged);

        void Remove(T entity);

        IQueryable<T> GetQuery();

        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter, bool asNoTracking = false);

    }
}
