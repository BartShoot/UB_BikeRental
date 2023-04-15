using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace UB_BikeRental.ViewModel
{
    public class VehicleItemViewModel
    {
        [Key]
        public int Id { get; set; }
        public List<VehicleDetailViewModel> Vehicles { get; set; }
    }
}
