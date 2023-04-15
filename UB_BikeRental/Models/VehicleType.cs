using UB_BikeRental.Interfaces;

namespace UB_BikeRental.Models
{
    public class VehicleType : IEntity<Guid>
	{
		public Guid Id { get; set; }
		public string Type { get; set; }
    }
}
