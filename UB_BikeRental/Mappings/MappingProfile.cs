using AutoMapper;
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
        }
    }
}