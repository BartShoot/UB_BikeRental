using UB_BikeRental.HelperClasses;
using UB_BikeRental.Models;

namespace UB_BikeRental.Interfaces
{
    public interface IReservationService : IRepositoryService<Reservation>
    {
        IQueryable<Reservation> GetReservationsForGuest(Guid guestId);
        IQueryable<Reservation> GetReservationsForGuestInTimeRange(Guid guestId, DateTime start, DateTime end);
        IQueryable<Reservation> GetReservationsForGuest(Guid guestId, DateTime start, DateTime end, ReservationStatus reservationStatus);

        ServiceResult ConfirmReservation(Guid id);
        ServiceResult CancelReservation(Guid id);

        ServiceResult CloseReservation(Guid id);
        ServiceResult ConfirmPaymentReservation(Guid id);
    }
}
