using InvestmentPortal.Domain.Core;

namespace InvestmentPortal.Core.Domain.Interfaces;

public interface IRepository<T> where T : Entity
{
    IQueryable<T> GetAll<T>() where T : Entity;
    T GetById<T>(int id) where T : Entity;
    T Add<T>(T entity) where T : Entity;
    T Update<T>(T entity) where T : Entity;
    void Remove<T>(T entity) where T : Entity;

    Task<IQueryable<T>> GetAllAsync<T>() where T : Entity;
    Task<T> GetByIdAsync<T>(int id) where T : Entity;
    Task<T> AddAsync<T>(T entity) where T : Entity;
    Task<T> UpdateAsync<T>(T entity) where T : Entity;
    Task RemoveAsync<T>(T entity) where T : Entity;
}
