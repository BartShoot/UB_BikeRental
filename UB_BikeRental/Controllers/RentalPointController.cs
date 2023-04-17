using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UB_BikeRental.InMemoryDB;
using UB_BikeRental.Models;
using UB_BikeRental.Services;
using UB_BikeRental.Validators;
using UB_BikeRental.ViewModel;

namespace UB_BikeRental.Controllers
{
    public class RentalPointController : Controller
    {
        private readonly InMemoryRepository<RentalPoint> _rentalPointRepository;
        private readonly RentalServiceDB _rentalServiceDB;
        private readonly IMapper _mapper;
        public RentalPointController(InMemoryRepository<RentalPoint> rentalPointRepository, 
            RentalServiceDB rentalServiceDB, IMapper mapper)
        {
            _rentalPointRepository = rentalPointRepository;
            _rentalServiceDB = rentalServiceDB;
            _mapper = mapper;
        }

        // GET: RentalPointController
        public ActionResult Index()
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

        // GET: RentalPointController/Details/5
        public ActionResult Details(Guid id)
        {
            var rentalPointVM = _mapper
                .Map<RentalPointDetailsViewModel>(_rentalPointRepository.GetById(id));

            return View(rentalPointVM);
        }

        // GET: RentalPointController/Create
        public ActionResult Create()
        {

            var rentalPointDetailVM = new RentalPointDetailsViewModel { Id = Guid.NewGuid() };
            return View(rentalPointDetailVM);
        }

        // POST: RentalPointController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RentalPointDetailsViewModel rentalPointDetailVM)
        {
            var validator = new RentalPointDetailsViewModelValidator();
            var validationResult = validator.Validate(rentalPointDetailVM);

            if (validationResult.IsValid)
            {
                var rentalPoint = _mapper.Map<RentalPoint>(rentalPointDetailVM);
                _rentalPointRepository.Insert(rentalPoint);
                return RedirectToAction("Index");
            }
            validationResult.Errors.ForEach(e => ModelState.AddModelError(e.PropertyName, e.ErrorMessage));
            return View(rentalPointDetailVM);
        }

        // GET: RentalPointController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var rentalPointVM = _mapper
                .Map<RentalPointDetailsViewModel>(_rentalPointRepository.GetById(id));
            return View(rentalPointVM);
        }

        // POST: RentalPointController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RentalPointDetailsViewModel rentalPointVM)
        {
            var validator = new RentalPointDetailsViewModelValidator();
            var validationResult = validator.Validate(rentalPointVM);

            if (validationResult.IsValid)
            {
                var rentalPoint = _mapper.Map<RentalPoint>(rentalPointVM);
                _rentalPointRepository.Update(rentalPoint);
                return RedirectToAction("Index");
            }
            validationResult.Errors
                .ForEach(e => ModelState.AddModelError(e.PropertyName, e.ErrorMessage));
            return View(rentalPointVM);
        }

        // GET: RentalPointController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var rentalPoint = _rentalPointRepository.GetById(id);

            return View(rentalPoint);
        }

        // POST: RentalPointController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(RentalPoint rentalPoint)
        {
            _rentalPointRepository.Delete(rentalPoint);
            return RedirectToAction("Index");
        }
    }
}
