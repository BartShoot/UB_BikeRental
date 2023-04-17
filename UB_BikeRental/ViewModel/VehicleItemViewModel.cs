using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UB_BikeRental.Models;

namespace UB_BikeRental.ViewModel
{
    public class VehicleItemViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        [NotMapped]
        public Guid VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; }
    }
}
