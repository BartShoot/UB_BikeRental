using System.Linq.Expressions;
using UB_BikeRental.HelperClasses;
using UB_BikeRental.Interfaces;

namespace UB_BikeRental.Services
{
    public class InMemoryRepository<T> : IRepositoryService<T> where T : class, IEntity<Guid>
    {
        protected static List<T> _set = new List<T>();
        public virtual ServiceResult Delete(T obj)
        {
            var toDelete = _set.SingleOrDefault(r => r.Id == obj.Id);

            if (toDelete != null)
            {
                _set.Remove(toDelete);
            }

            return ServiceResult.CommonResults["OK"];
        }
        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public ServiceResult Insert(T obj)
        {
            throw new NotImplementedException();
        }

        public ServiceResult Save()
        {
            throw new NotImplementedException();
        }

        public ServiceResult Update(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
