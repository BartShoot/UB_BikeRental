using System.ComponentModel.DataAnnotations;

namespace UB_BikeRental.ViewModel
{
    public class RentalPointItemViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
