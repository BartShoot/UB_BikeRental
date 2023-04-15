using System.ComponentModel.DataAnnotations.Schema;
using UB_BikeRental.HelperClasses;
using UB_BikeRental.Interfaces;

namespace UB_BikeRental.Models
{
    public class Reservation : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime ReturnDate { get; set; }
        [NotMapped]
        public ReservationStatus ReservationStatus { get; set; }
        public Vehicle Vehicle { get; set; }
        public decimal TotalCost { get; set; }
    }
}
