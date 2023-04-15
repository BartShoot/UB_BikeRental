using UB_BikeRental.Models;

namespace UB_BikeRental.ViewModel
{
    public class VehicleDetailViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public VehicleType VehicleType { get; set; }
    }
}
