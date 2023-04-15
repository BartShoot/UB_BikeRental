using Microsoft.EntityFrameworkCore;
using UB_BikeRental.Models;
using UB_BikeRental.ViewModel;

namespace UB_BikeRental.InMemoryDB
{
	public class RentalServiceDB : DbContext
	{
		public RentalServiceDB(DbContextOptions<RentalServiceDB> options) : base(options)
		{ 

		}
		public DbSet<Vehicle> Vehicles { get; set; }
		public DbSet<Reservation> Reservations { get; set; }
		public DbSet<RentalPoint> RentalPoints { get; set; }
		public DbSet<VehicleType> VehicleTypes { get; set; }
		public DbSet<UB_BikeRental.ViewModel.VehicleItemViewModel> VehicleItemViewModel { get; set; } = default!;
		public DbSet<UB_BikeRental.ViewModel.VehicleDetailViewModel> VehicleDetailViewModel { get; set; } = default!;
	}
}
