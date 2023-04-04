using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using UB_BikeRental.HelperClasses;
using UB_BikeRental.Interfaces;

namespace UB_BikeRental.Services
{
    /*
    public class ReservationService : InMemoryRepository<Reservation>, IReservationService
    {
        public ReservationService(DbContext context) : base(context) 
        {

        }

        protected ServiceResult SetStatus(Reservation reservation, ReservationStatus status)
        {
            if (reservation != null)
            {
                reservation.ReservationStatus = ReservationStatus.Canceled;

                var result = Update(reservation);

                return result;
            }
            return ServiceResult.CommonResults["NotFound"];
        }

        public ServiceResult CancelReservation(Guid id)
        {
            var reservation = GetById(id);
            return SetStatus(reservation, ReservationStatus.Canceled);
        }

        public ServiceResult CloseReservation(Guid id)
        {
            var reservation = GetById(id);
            return SetStatus(reservation, ReservationStatus.ClosedAndNotPaid);
        }

        public ServiceResult ConfirmPaymentReservation(Guid id)
        {
            var reservation = GetById(id);

            if (reservation.ReservationStatus != ReservationStatus.Canceled && 
                reservation.ReservationStatus != ReservationStatus.Rejected)
            {
                return SetStatus(reservation, ReservationStatus.ClosedAndPaid);
            }
            return new ServiceResult()
            {
                Result = ServiceResultStatus.Error,
                Messages = new List<string>
                {
                    "Status ustawiony na anulowany",
                    "lub",
                    "Status ustawiony na Odrzucony",
                }
            };
        }

        public ServiceResult ConfirmReservation(Guid id)
        {
            throw new NotImplementedException();
        }

        public ServiceResult Delete(Reservation obj)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Reservation> FindBy(System.Linq.Expressions.Expression<Func<Reservation, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Reservation> GetReservationsForGuest(Guid guestId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Reservation> GetReservationsForGuest(Guid guestId, DateTime start, DateTime end, ReservationStatus reservationStatus)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Reservation> GetReservationsForGuestInTimeRange(Guid guestId, DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public ServiceResult Insert(Reservation obj)
        {
            throw new NotImplementedException();
        }

        public ServiceResult Update(Reservation obj)
        {
            throw new NotImplementedException();
        }

        IQueryable<Reservation> IRepositoryService<Reservation>.GetAll()
        {
            throw new NotImplementedException();
        }

        Reservation IRepositoryService<Reservation>.GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
    */
}
