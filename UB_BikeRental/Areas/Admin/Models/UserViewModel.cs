namespace UB_BikeRental.Areas.Admin.Models
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string email { get; set; }
        public string Role { get; set; }
    }
}
