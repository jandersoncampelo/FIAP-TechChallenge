using Infrastructure.Persistence;
using InvestmentPortal.API.Persistence.Interfaces;
using InvestmentPortal.Domain.Core;

namespace InvestmentPortal.API.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected MainContext _context;

        public Repository(MainContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public IList<T> GetAll<T>() where T : class
        {
            return _context.Set<T>().ToList();
        }

        public T GetById<T>(int id) where T : class
        {
            return _context.Set<T>().Find(id);
        }

        public void Remove<T>(T entity) where T : class
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}
