using InvestmentPortal.Domain.Core;

namespace InvestmentPortal.API.Persistence.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        IList<T> GetAll<T>() where T : class;
        T GetById<T>(int id) where T : class;
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;
    }
}
