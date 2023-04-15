using UB_BikeRental.Models;

namespace UB_BikeRental.InMemoryDB
{
    public class InitialData
    {
        public static void Initialize(RentalServiceDB _context)
        {
            var vType1 = new VehicleType { Id = new Guid(), Type = "Górski" };
            var vType2 = new VehicleType { Id = new Guid(), Type = "Miejski" };
            var vType3 = new VehicleType { Id = new Guid(), Type = "Szosowy" };
            var vType4 = new VehicleType { Id = new Guid(), Type = "Towarowy" };
            _context.VehicleTypes.AddRange(vType1, vType2, vType3, vType4);
            _context.SaveChanges();

            var vehicle1 = new Vehicle { Id = new Guid(), Name = "MNT 3000 PRO", Price = 40.0, Type = vType1 };
            var vehicle2 = new Vehicle { Id = new Guid(), Name = "CTY 1000 LITE", Price = 10.0, Type = vType2 };
            var vehicle3 = new Vehicle { Id = new Guid(), Name = "SPD 2000", Price = 50.0, Type = vType3 };
            var vehicle4 = new Vehicle { Id = new Guid(), Name = "CRG 8000", Price = 20.0, Type = vType4 };
            _context.Vehicles.AddRange(vehicle1, vehicle2, vehicle3, vehicle4);
            _context.SaveChanges();

            var rentalPoints = new List<RentalPoint>
            {
                new RentalPoint { Id = new Guid(), Name = "UBB", Address = "Willowa 2", Vehicles = new List<Vehicle> { vehicle1, vehicle3 } },
                new RentalPoint { Id = new Guid(), Name = "Centrum", Address = "Rynek 14", Vehicles = new List<Vehicle> { vehicle2, vehicle4 } }
            };
            _context.RentalPoints.AddRange(rentalPoints);
            _context.SaveChanges();
        }
    }
}
