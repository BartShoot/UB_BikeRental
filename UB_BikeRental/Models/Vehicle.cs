using UB_BikeRental.Interfaces;

namespace UB_BikeRental.Models
{
    public class Vehicle : IEntity<Guid>
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
        public double Price { get; set; }
        public VehicleType Type { get; set; }
	}
}
