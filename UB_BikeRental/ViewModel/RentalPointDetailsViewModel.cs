using System.ComponentModel.DataAnnotations;
using UB_BikeRental.Models;

namespace UB_BikeRental.ViewModel
{
    public class RentalPointDetailsViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }
}
