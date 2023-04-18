using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UB_BikeRental.Models;
using UB_BikeRental.ViewModel;

namespace UB_BikeRental.InMemoryDB
{
	public class RentalServiceDB : IdentityDbContext
    {
        public RentalServiceDB(DbContextOptions<RentalServiceDB> options) : base(options)
		{ 

		}
		public DbSet<Vehicle> Vehicles { get; set; }
		public DbSet<Reservation> Reservations { get; set; }
		public DbSet<RentalPoint> RentalPoints { get; set; }
		public DbSet<VehicleType> VehicleTypes { get; set; }
		public DbSet<UB_BikeRental.ViewModel.VehicleItemViewModel> VehicleItemViewModel { get; set; } = default!;
		public DbSet<UB_BikeRental.ViewModel.VehicleDetailsViewModel> VehicleDetailViewModel { get; set; } = default!;
		public DbSet<UB_BikeRental.ViewModel.RentalPointItemViewModel> RentalPointItemViewModel { get; set; } = default!;
		public DbSet<UB_BikeRental.ViewModel.RentalPointDetailsViewModel> RentalPointDetailsViewModel { get; set; } = default!;
	}
}
