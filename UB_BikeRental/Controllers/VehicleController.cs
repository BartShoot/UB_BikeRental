﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Reflection;
using UB_BikeRental.Models;

namespace UB_BikeRental.Controllers
{
    public class VehicleController : Controller
    {
        List<Vehicle> model = new List<Vehicle>();

        // GET: VehicleController
        [Route("Vehicle/VehicleList")]
        public ActionResult VehicleList()
        {
            model.Add(new Vehicle { Id = 0, Name = "Rower 1", Location = 1 });
            model.Add(new Vehicle { Id = 1, Name = "Rower 2", Location = 1 });
            model.Add(new Vehicle { Id = 2, Name = "Rower 3", Location = 2 });
            return View(model);
        }

        // GET: VehicleController/Details/5
        public ActionResult Details(int id)
        { 
            var det = model[id];
            return View(det);
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