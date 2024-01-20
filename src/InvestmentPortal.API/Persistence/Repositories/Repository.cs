using Infrastructure.Persistence;
using InvestmentPortal.API.Persistence.Interfaces;
using InvestmentPortal.Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPortal.API.Persistence.Repositories
{
    public class Repository<T>(MainContext context) : IRepository<T> where T : Entity
    {
        protected MainContext _context = context;

        public void Add<T>(T entity) where T : Entity
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public async Task AddAsync<T>(T entity) where T : Entity
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> GetAll<T>() where T : Entity
        {
            return _context.Set<T>();
        }

        public async Task<IQueryable<T>> GetAllAsync<T>() where T : Entity
        {
            return await Task.Run(() => _context.Set<T>());
        }

        public T GetById<T>(int id) where T : Entity
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<T> GetByIdAsync<T>(int id) where T : Entity
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void Remove<T>(T entity) where T : Entity
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public async Task RemoveAsync<T>(T entity) where T : Entity
        {
            await Task.Run(() => _context.Set<T>().Remove(entity));
            await _context.SaveChangesAsync();
        }

        public void Update<T>(T entity) where T : Entity
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        public async Task UpdateAsync<T>(T entity) where T : Entity
        {
            await Task.Run(() => _context.Set<T>().Update(entity));
            await _context.SaveChangesAsync();

        }
    }
}
