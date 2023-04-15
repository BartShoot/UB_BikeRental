using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            var vehicles = _vehicleRepository.GetAll().Include(v => v.Type);

            var vehicleViewModels = vehicles.Select(v => new VehicleDetailViewModel
            {
                Id = v.Id,
                Name = v.Name,
                Price = v.Price,
                VehicleType = v.Type
            }).ToList();

            var vehicleItemViewModel = new VehicleItemViewModel
            {
                Vehicles = vehicleViewModels
            };
            return View(vehicleItemViewModel);
        }

        // GET: VehicleController/Details/5
        public ActionResult Details(Guid id)
        {
            var vehicle = _vehicleRepository.GetById(id);
            var vehicleDetailViewModel = new VehicleDetailViewModel
            {
                Id = vehicle.Id,
                Name = vehicle.Name,
                Price = vehicle.Price,
                VehicleType = vehicle.Type
            };
            return View(vehicleDetailViewModel);
        }

        // GET: VehicleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VehicleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VehicleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
