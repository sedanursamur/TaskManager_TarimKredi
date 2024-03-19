using Microsoft.EntityFrameworkCore;
using TaskManager.TaskTrackingApp.DataAccess.Context;
using TaskManager.TaskTrackingApp.DataAccess.Interfaces;
using TaskManager.TaskTrackingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.TaskTrackingApp.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly TaskTrackingContext _context;

        public Repository(TaskTrackingContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task<T> FindAsync(object id)
        {
            var data = await _context.Set<T>().FindAsync(id);
            return data;
        }

        public async Task<List<T>> GetAllAsync()
        {
            var list = await _context.Set<T>().ToListAsync();
            return list; 
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            var list = await _context.Set<T>().AsNoTracking().Where(filter).ToListAsync();
            return list;
        }

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {
            return !asNoTracking ? await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter) :
                await _context.Set<T>().SingleOrDefaultAsync(filter);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T unchanged, T updated)
        {
            _context.Update(updated);
             //_context.Entry(unchanged).CurrentValues.SetValues(updated);
        }
        public IQueryable<T> GetQueryable()
        { 
            return _context.Set<T>().AsQueryable();
        }
        public IQueryable<T> GetQueryable(int id)
        {
            return _context.Set<T>().AsQueryable().Where(x=>x.Id ==id);
        }
    }
}
