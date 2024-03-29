﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UB_BikeRental.Areas.Admin.Models;
using UB_BikeRental.InMemoryDB;
using UB_BikeRental.Models;
using UB_BikeRental.Services;
using UB_BikeRental.ViewModel;

namespace UB_BikeRental.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class HomeController : Controller
    {
        RentalServiceDB _context;
        private readonly InMemoryRepository<Reservation> _reservationRepository;
        IMapper _mapper;
        UserManager<IdentityUser> _userManager;

        public HomeController (RentalServiceDB context, IMapper mapper, UserManager<IdentityUser> userManager, InMemoryRepository<Reservation> reservationRepository)
        {
            _reservationRepository = reservationRepository;
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var userList = _context.Users.ToList();
            List<UserViewModel> UserList = new List<UserViewModel>();
            foreach (var item in userList)
            {
                UserList.Add(_mapper.Map<UserViewModel>(item));
                UserList[UserList.Count - 1].Role = 
                    (await _userManager.GetRolesAsync(item)).LastOrDefault();
            }
            return View(UserList);
        }
        public async Task<IActionResult> ReservationListAsync()
        {
            var reservationList = _context.Reservations.ToList();
            List<ReservationDetailsViewModel> ReservationList = new List<ReservationDetailsViewModel>();
            foreach (var item in reservationList)
            {
                ReservationList.Add(_mapper.Map<ReservationDetailsViewModel>(item));
            }
            return View(ReservationList);
        }

        public IActionResult ConfirmReservation(Guid id)
        {
            var reservationVM = _mapper.Map<ReservationDetailsViewModel>(_reservationRepository.GetById(id));
            return View(reservationVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmReservation(ReservationDetailsViewModel reservation)
        {
            _reservationRepository.Delete(_reservationRepository.GetById(reservation.Id));
            return RedirectToAction("ReservationList");
        }

        [HttpPost]
        public async Task<IActionResult> SetOperatorRole(Guid userId)
        {
			var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return RedirectToAction("Index");
            }
            await _userManager.AddToRoleAsync(user, "Operator");
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
