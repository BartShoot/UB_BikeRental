using System.Linq.Expressions;
using UB_BikeRental.HelperClasses;
using UB_BikeRental.InMemoryDB;
using UB_BikeRental.Interfaces;

namespace UB_BikeRental.Services
{
    public class InMemoryRepository<T> : IRepositoryService<T> where T : class, IEntity<Guid>
    {
        private readonly RentalServiceDB _rentalServiceDB;
        public InMemoryRepository(RentalServiceDB rentalServiceDB)
        {
            _rentalServiceDB = rentalServiceDB;
        }
        public virtual ServiceResult Delete(T obj)
        {
            _rentalServiceDB.Set<T>().Remove(obj);
            _rentalServiceDB.SaveChanges();

			return ServiceResult.CommonResults["OK"];
        }
        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _rentalServiceDB.Set<T>().AsQueryable<T>().Where(predicate);

            return query;
        }

        public IQueryable<T> GetAll()
        {
            return _rentalServiceDB.Set<T>().AsQueryable<T>();
        }

        public T GetById(Guid id)
        {
            var result = _rentalServiceDB.Set<T>().FirstOrDefault(r => r.Id == id);

            return result;
        }

        public ServiceResult Insert(T obj)
        {
			_rentalServiceDB.Set<T>().Add(obj);
            _rentalServiceDB.SaveChanges();

            return ServiceResult.CommonResults["OK"];
        }

        public ServiceResult Save()
        {
            return ServiceResult.CommonResults["OK"];
        }

        public ServiceResult Update(T obj)
        {
            var toUpdate = _rentalServiceDB.Set<T>().Update(obj);
            _rentalServiceDB.SaveChanges();

            return ServiceResult.CommonResults["OK"];
        }
    }
}
