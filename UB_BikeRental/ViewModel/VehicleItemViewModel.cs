using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace UB_BikeRental.ViewModel
{
    public class VehicleItemViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
