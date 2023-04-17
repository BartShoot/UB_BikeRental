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
using UB_BikeRental.ViewModel;

namespace UB_BikeRental.Controllers
{
    public class VehicleController : Controller
    {
        private readonly InMemoryRepository<Vehicle> _vehicleRepository;
        private readonly RentalServiceDB _rentalServiceDB;
        public VehicleController(InMemoryRepository<Vehicle> vehicleRepository, RentalServiceDB rentalServiceDB)
        {
            _vehicleRepository = vehicleRepository;
            _rentalServiceDB = rentalServiceDB;
        }

        // GET: VehicleController
        [HttpGet]
        public ActionResult Index()
        {
            var vehicles = _vehicleRepository.GetAll();

            List<VehicleItemViewModel> VehicleList = new List<VehicleItemViewModel>();

            foreach (var item in vehicles)
            {
                var tmp = new VehicleItemViewModel();

                tmp.Id = item.Id;
                tmp.Name = item.Name;
                tmp.Price = item.Price;

                VehicleList.Add(tmp);
            }

            return View(VehicleList);
        }

        // GET: VehicleController/Details/5
        public ActionResult Details(Guid id)
        {
            var vehicle = _vehicleRepository.GetById(id);
            var vehicleDetailViewModel = new VehicleDetailsViewModel
            {
                Id = vehicle.Id,
                Name = vehicle.Name,
                Price = vehicle.Price,
                VehicleType = vehicle.Type
            };
            return View(vehicleDetailViewModel);
        }

        // GET: VehicleController/Create
        [HttpGet]
        public ActionResult Create()
        {
            var vehicleDetailVM = new VehicleDetailsViewModel
            {
                Id = Guid.NewGuid(),
                VehicleType = _rentalServiceDB.VehicleTypes.First()
            };
            return View(vehicleDetailVM);
        }

        // POST: VehicleController/Create
        [HttpPost]
        public ActionResult Create(VehicleDetailsViewModel vehicleDetailVM)
        {
            var vehicle = new Vehicle
            {
                Id = vehicleDetailVM.Id,
                Name = vehicleDetailVM.Name,
                Price = vehicleDetailVM.Price,
                Type = vehicleDetailVM.VehicleType
            };
            _vehicleRepository.Insert(vehicle);
            return RedirectToAction("Index");
        }

        // GET: VehicleController/Edit/5
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var vehicle = _vehicleRepository.GetById(id);
            return View(vehicle);
        }

        // POST: VehicleController/Edit/5
        [HttpPost]
        public ActionResult Edit(Vehicle vehicle)
        {
            _vehicleRepository.Update(vehicle);
            return RedirectToAction("Index");
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
