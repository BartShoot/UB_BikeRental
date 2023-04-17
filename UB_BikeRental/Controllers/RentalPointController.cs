using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UB_BikeRental.InMemoryDB;
using UB_BikeRental.Models;
using UB_BikeRental.Services;
using UB_BikeRental.ViewModel;

namespace UB_BikeRental.Controllers
{
    public class RentalPointController : Controller
    {
        private readonly InMemoryRepository<RentalPoint> _rentalPointRepository;
        private readonly RentalServiceDB _rentalServiceDB;
        public RentalPointController(InMemoryRepository<RentalPoint> rentalPointRepository, RentalServiceDB rentalServiceDB)
        {
            _rentalPointRepository = rentalPointRepository;
            _rentalServiceDB = rentalServiceDB;
        }
        // GET: RentalPointController
        public ActionResult Index()
        {
            var rentalsPoints = _rentalPointRepository.GetAll();

            List<RentalPointItemViewModel> RentalPointList
                = new List<RentalPointItemViewModel>();

            foreach (var item in rentalsPoints)
            {
                var tmp = new RentalPointItemViewModel();

                tmp.Id = item.Id;
                tmp.Name = item.Name;
                tmp.Location = item.Address;

                RentalPointList.Add(tmp);
            }
            return View(RentalPointList);
        }

        // GET: RentalPointController/Details/5
        public ActionResult Details(Guid id)
        {
            var rentalPoint = _rentalPointRepository.GetById(id);
            var rentalPointDetailViewModel = new RentalPointDetailsViewModel
            {
                Id = rentalPoint.Id,
                Name = rentalPoint.Name,
                Address = rentalPoint.Address,
                Vehicles = rentalPoint.Vehicles,
            };

            return View(rentalPointDetailViewModel);
        }

        // GET: RentalPointController/Create
        public ActionResult Create()
        {
            var rentalPointDetailVM = new RentalPointDetailsViewModel
            {
                Id = Guid.NewGuid(),
            };
            return View(rentalPointDetailVM);
        }

        // POST: RentalPointController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RentalPointDetailsViewModel rentalPointDetailVM)
        {
            var rentalPoint = new RentalPoint
            {
                Id = rentalPointDetailVM.Id,
                Name = rentalPointDetailVM.Name,
                Address = rentalPointDetailVM.Address,
                Vehicles = rentalPointDetailVM.Vehicles
            };
            _rentalPointRepository.Insert(rentalPoint);
            return RedirectToAction("Index");
        }

        // GET: RentalPointController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var rentalPoint = _rentalPointRepository.GetById(id);
            return View(rentalPoint);
        }

        // POST: RentalPointController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RentalPoint rentalPoint)
        {
            _rentalPointRepository.Update(rentalPoint);
            return RedirectToAction("Index");
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
