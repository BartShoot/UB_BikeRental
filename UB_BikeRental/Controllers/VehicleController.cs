using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using System.Linq;
using System.Reflection;
using UB_BikeRental.InMemoryDB;
using UB_BikeRental.Interfaces;
using UB_BikeRental.Models;
using UB_BikeRental.Services;
using UB_BikeRental.Validators;
using UB_BikeRental.ViewModel;

namespace UB_BikeRental.Controllers
{
    public class VehicleController : Controller
    {
        private readonly InMemoryRepository<Vehicle> _vehicleRepository;
        private readonly RentalServiceDB _rentalServiceDB;
        private readonly IMapper _mapper;
        public VehicleController(InMemoryRepository<Vehicle> vehicleRepository, 
            RentalServiceDB rentalServiceDB, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _rentalServiceDB = rentalServiceDB;
            _mapper = mapper;
        }

        // GET: VehicleController
        [HttpGet]
        public ActionResult Index()
        {
            var vehicles = _vehicleRepository.GetAll().Include(x => x.Type);

            List<VehicleItemViewModel> VehicleList = new List<VehicleItemViewModel>();

            foreach (var item in vehicles)
            {
                VehicleList.Add(_mapper
                    .Map<VehicleItemViewModel>(item));
            }

            return View(VehicleList);
        }

        // GET: VehicleController/Details/5
        public ActionResult Details(Guid id)
        {
            var vehicleDetailViewModel = _mapper
                .Map<VehicleDetailsViewModel>(_vehicleRepository.GetById(id));

            return View(vehicleDetailViewModel);
        }

        // GET: VehicleController/Create
        public ActionResult Create()
        {
            var vehicleDetailVM = new VehicleDetailsViewModel { Id = Guid.NewGuid() };
            return View(vehicleDetailVM);
        }

        // POST: VehicleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehicleDetailsViewModel vehicleDetailVM)
        {
            var validator = new VehicleDetailsViewModelValidator();
            var validationResult = validator.Validate(vehicleDetailVM);

            if (validationResult.IsValid)
            {
                var vehicle = _mapper.Map<Vehicle>(vehicleDetailVM);
                _vehicleRepository.Insert(vehicle);
                return RedirectToAction("Index");
            }
            validationResult.Errors.ForEach(e => ModelState.AddModelError(e.PropertyName, e.ErrorMessage));
            return View(vehicleDetailVM);
        }

        // GET: VehicleController/Edit/5
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var vehicleDetailVM = _mapper
                .Map<VehicleDetailsViewModel>(_vehicleRepository.GetById(id));
            return View(vehicleDetailVM);
        }

        // POST: VehicleController/Edit/5
        [HttpPost]
        public ActionResult Edit(VehicleDetailsViewModel vehicleVM)
        {
            var validator = new VehicleDetailsViewModelValidator();
            var validationResult = validator.Validate(vehicleVM);

            if (validationResult.IsValid)
            {
                var vehicle = _mapper.Map<Vehicle>(vehicleVM);
                _vehicleRepository.Insert(vehicle);
                return RedirectToAction("Index");
            }
            validationResult.Errors
                .ForEach(e => ModelState.AddModelError(e.PropertyName, e.ErrorMessage));
            return View(vehicleVM);
        }

        // GET: VehicleController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var vehicle = _vehicleRepository.GetById(id);
            
            return View(vehicle);
        }

        // POST: VehicleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Vehicle vehicle)
        {
            _vehicleRepository.Delete(vehicle);
            return RedirectToAction("Index");
        }
    }
}
