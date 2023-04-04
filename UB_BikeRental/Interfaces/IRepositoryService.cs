using System.Linq.Expressions;
using UB_BikeRental.HelperClasses;

namespace UB_BikeRental.Interfaces
{
    public interface IRepositoryService<T> where T : IEntity<Guid>
    {
        IQueryable<T> GetAll();
        T GetById(Guid id);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        ServiceResult Insert(T obj);
        ServiceResult Update(T obj);
        ServiceResult Delete(T obj);
        ServiceResult Save();
    }
}
