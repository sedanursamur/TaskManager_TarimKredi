using Microsoft.EntityFrameworkCore;
using TaskManager.TaskTrackingApp.DataAccess.Context;
using TaskManager.TaskTrackingApp.DataAccess.Interfaces;
using TaskManager.TaskTrackingApp.DataAccess.Repositories;
using TaskManager.TaskTrackingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.TaskTrackingApp.DataAccess.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly TaskTrackingContext _context;

        public Uow(TaskTrackingContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> AddAsync<TEntity>(TEntity entity) where TEntity : class
        {
            
            var addedEntity = _context.Set<TEntity>().Add(entity).Entity;
           
            await _context.SaveChangesAsync();
          
            return addedEntity;
        }

    }
}
