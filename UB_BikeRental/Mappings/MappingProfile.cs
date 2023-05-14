using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UB_BikeRental.Areas.Admin.Models;
using UB_BikeRental.Models;
using UB_BikeRental.ViewModel;

namespace UB_BikeRental.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Vehicle, VehicleDetailsViewModel>().ReverseMap();
            CreateMap<Vehicle, VehicleItemViewModel>().ReverseMap();

            CreateMap<RentalPoint, RentalPointDetailsViewModel>().ReverseMap();
            CreateMap<RentalPoint, RentalPointItemViewModel>().ReverseMap();

            CreateMap<Reservation, ReservationsDetailsViewModel>().ReverseMap();
            CreateMap<IdentityUser, UserViewModel>().ReverseMap();
        }
    }
}