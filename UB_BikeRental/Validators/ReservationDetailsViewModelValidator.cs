using FluentValidation;
using UB_BikeRental.ViewModel;

namespace UB_BikeRental.Validators
{
    internal class ReservationDetailsViewModelValidator : AbstractValidator<ReservationDetailsViewModel>
    {
        public ReservationDetailsViewModelValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty().MinimumLength(3).WithMessage("Nazwa użytkownika musi być dłuższa niż 3 znaki");
            RuleFor(x => x.PickUpDate).NotEmpty().WithMessage("Nazwa musi być dłuższa niż 3 znaki");
            RuleFor(x => x.ReturnDate).NotEmpty()
                .Must((model, ReturnDate) => ReturnDate > model.PickUpDate)
                .WithMessage("Data zakonczenia nie może być przed datą wypożyczenia");
            RuleFor(x => x.Vehicle).NotEmpty().WithMessage("Musi być przypisany rower");
        }
    }
}