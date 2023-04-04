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
            IQueryable<T> query = _set.AsQueryable<T>().Where(predicate);

            return query;
        }

        public IQueryable<T> GetAll()
        {
            return _set.AsQueryable<T>();
        }

        public T GetById(Guid id)
        {
            var result = _set.FirstOrDefault(r => r.Id == id);

            return result;
        }

        public ServiceResult Insert(T obj)
        {
            _set.Add(obj);

            return ServiceResult.CommonResults["OK"];
        }

        public ServiceResult Save()
        {
            return ServiceResult.CommonResults["OK"];
        }

        public ServiceResult Update(T obj)
        {
            var toUpdate = _set.SingleOrDefault(r => r.Id == obj.Id);

            return ServiceResult.CommonResults["OK"];
        }
    }
}
