using FluentValidation;
using UB_BikeRental.ViewModel;

namespace UB_BikeRental.Validators
{
    internal class RentalPointDetailsViewModelValidator : AbstractValidator<RentalPointDetailsViewModel>
    {
        public RentalPointDetailsViewModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3).WithMessage("Nazwa musi być dłuższa niż 3 znaki");
            RuleFor(x => x.Address).NotEmpty().MinimumLength(3).WithMessage("Lokalizacja musi być dłuższa niż 3 znaki");
        }
    }
}