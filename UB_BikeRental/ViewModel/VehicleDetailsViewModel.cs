using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UB_BikeRental.Models;

namespace UB_BikeRental.ViewModel
{
    public class VehicleDetailsViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public VehicleType VehicleType { get; set; }
    }
}
