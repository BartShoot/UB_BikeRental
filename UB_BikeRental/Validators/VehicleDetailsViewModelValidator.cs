using FluentValidation;
using UB_BikeRental.ViewModel;

namespace UB_BikeRental.Validators
{
    internal class VehicleDetailsViewModelValidator : AbstractValidator<VehicleDetailsViewModel>
    {
        public VehicleDetailsViewModelValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3).WithMessage("Nazwa musi być dłuższa niż 3 znaki");
            RuleFor(x => x.Price).NotEmpty().GreaterThan(0).WithMessage("Cena nie może być ujemna");
            RuleFor(x => x.VehicleType).NotEmpty().WithMessage("Musi być jakiegoś typu");
        }
    }
}