using UB_BikeRental.Interfaces;

namespace UB_BikeRental.Models
{
    public class RentalPoint : IEntity<Guid>
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
        public string Address { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }
}
    