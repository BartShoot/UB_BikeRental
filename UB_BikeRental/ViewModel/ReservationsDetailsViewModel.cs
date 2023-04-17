using System.ComponentModel.DataAnnotations.Schema;
using UB_BikeRental.HelperClasses;
using UB_BikeRental.Models;

namespace UB_BikeRental.ViewModel
{
    internal class ReservationsDetailsViewModel
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public Vehicle Vehicle { get; set; }
        public decimal TotalCost { get; set; }
    }
}