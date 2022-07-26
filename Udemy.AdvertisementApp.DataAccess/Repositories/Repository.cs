using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Udemy.Adversitement.Common.Enums;
using Udemy.Advertisement.Entities;
using Udemy.AdvertisementApp.DataAccess.Contexts;

namespace Udemy.AdvertisementApp.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AdvertisementContext _context;

        public Repository(AdvertisementContext context)
        {
            _context = context;
        }
        //İlgili entity tablosundaki tüm verileri getirir.
        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {

            return await _context.Set<T>().Where(filter).AsNoTracking().ToListAsync();
        }

        //OrderBy kullanmak için Generic bir seçici alıyoruz.

        //Default olarak Desc type varsayarak sıralama yapsın
        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> selector,
            OrderByType type = OrderByType.DESC)
        {
            return type == OrderByType.DESC ? await _context.Set<T>().OrderByDescending(selector).AsNoTracking().ToListAsync()
                : await _context.Set<T>().OrderBy(selector).AsNoTracking().ToListAsync();
        }
        //istenilen şarta göre sıralama yapan 
        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> selector,
            OrderByType type = OrderByType.DESC)
        {
            return type == OrderByType.DESC ? await _context.Set<T>().Where(filter).AsNoTracking().OrderByDescending(selector).ToListAsync()
                :await _context.Set<T>().Where(filter).AsNoTracking().OrderBy(selector).ToListAsync();
        }
        public async Task<T> FindAsync(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }
        public void Update(T entity, T unchanged)
        {
            _context.Entry(unchanged).CurrentValues.SetValues(entity);
        }
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public IQueryable<T> GetQuery()
        {
            return _context.Set<T>().AsQueryable();
        }
        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {
            return !asNoTracking ? await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter):
                await _context.Set<T>().SingleOrDefaultAsync(filter);
        }


    }
}
