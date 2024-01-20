using InvestmentPortal.Domain.Core;

namespace InvestmentPortal.API.Persistence.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        IQueryable<T> GetAll<T>() where T : Entity;
        T GetById<T>(int id) where T : Entity;
        void Add<T>(T entity) where T : Entity;
        void Update<T>(T entity) where T : Entity;
        void Remove<T>(T entity) where T : Entity;

        Task<IQueryable<T>> GetAllAsync<T>() where T : Entity;
        Task<T> GetByIdAsync<T>(int id) where T : Entity;
        Task AddAsync<T>(T entity) where T : Entity;
        Task UpdateAsync<T>(T entity) where T : Entity;
        Task RemoveAsync<T>(T entity) where T : Entity;
    }
}
