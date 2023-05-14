using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UB_BikeRental.Areas.Admin.Models;
using UB_BikeRental.InMemoryDB;
using UB_BikeRental.Models;
using UB_BikeRental.ViewModel;

namespace UB_BikeRental.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class HomeController : Controller
    {
        RentalServiceDB _context;
        IMapper _mapper;
        UserManager<IdentityUser> _userManager;

        public HomeController (RentalServiceDB context, IMapper mapper, UserManager<IdentityUser> userManager)
        {
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
                UserList.Add(_mapper
                    .Map<UserViewModel>(item));
                UserList[UserList.Count - 1].Role = (await _userManager.GetRolesAsync(item)).LastOrDefault();
            }
            return View(UserList);
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
