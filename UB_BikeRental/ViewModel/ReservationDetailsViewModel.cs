using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UB_BikeRental.HelperClasses;
using UB_BikeRental.Models;

namespace UB_BikeRental.ViewModel
{
    public class ReservationDetailsViewModel
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        [DataType(DataType.Date)]
        public DateTime PickUpDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }
        public Guid RentalPointID { get; set; }
        public RentalPoint RentalPoint { get; set; }
        public Guid VehicleID { get; set; }
        public Vehicle Vehicle { get; set; }
        public decimal TotalCost { get; set; }

        public IEnumerable <SelectListItem> Vehicles { get; set; }
    }
}