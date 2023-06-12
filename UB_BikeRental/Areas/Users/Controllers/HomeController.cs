using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UB_BikeRental.InMemoryDB;
using UB_BikeRental.Models;
using UB_BikeRental.Services;
using UB_BikeRental.Validators;
using UB_BikeRental.ViewModel;

namespace UB_BikeRental.Areas.Users.Controllers
{
    [Area("Users")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly InMemoryRepository<Reservation> _reservationRepository;
        private readonly InMemoryRepository<RentalPoint> _rentalPointRepository;
		private readonly InMemoryRepository<Vehicle> _vehicleRepository;
		private readonly RentalServiceDB _rentalServiceDB;
        private readonly IMapper _mapper;
        public HomeController(InMemoryRepository<Reservation> reservationRepository,
            InMemoryRepository<RentalPoint> rentalPointRepository,
		InMemoryRepository<Vehicle> vehicleRepository,
		RentalServiceDB rentalServiceDB, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _rentalPointRepository = rentalPointRepository;
            _vehicleRepository = vehicleRepository;
            _rentalServiceDB = rentalServiceDB;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var rentalsPoints = _rentalPointRepository.GetAll();

            List<RentalPointItemViewModel> RentalPointList
                = new List<RentalPointItemViewModel>();

            foreach (var item in rentalsPoints)
            {
                RentalPointList.Add(_mapper
                    .Map<RentalPointItemViewModel>(item));
            }
            return View(RentalPointList);
        }

        public IActionResult MakeReservation(Guid id)
        {
            var vehicles = _rentalServiceDB.Vehicles.Select(v => new SelectListItem { Value = v.Id.ToString(), Text = v.Name + " " + v.Price }).ToList();
            var reservation = new ReservationDetailsViewModel { 
                Id = new Guid(),
                CustomerName = User.Identity.Name,
                PickUpDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(1),
                RentalPointID = id,
                RentalPoint = _rentalPointRepository.GetById(id),
                Vehicles = vehicles 
            };
            return View(reservation);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MakeReservation(ReservationDetailsViewModel reservationVM)
        {
            reservationVM.Vehicle = _vehicleRepository.GetById(reservationVM.VehicleID);
			reservationVM.RentalPoint = _rentalPointRepository.GetById(reservationVM.RentalPointID);
			var validator = new ReservationDetailsViewModelValidator();
            var validationResult = validator.Validate(reservationVM);

            if (validationResult.IsValid)
            {
                var reservation = _mapper.Map<Reservation>(reservationVM);
                _reservationRepository.Insert(reservation);
                return RedirectToAction("Index");
            }
            validationResult.Errors.ForEach(e => ModelState.AddModelError(e.PropertyName, e.ErrorMessage));
            return RedirectToAction("Index");
        }
    }
}
