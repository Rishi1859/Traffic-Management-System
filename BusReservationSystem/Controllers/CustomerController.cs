using Bus.DataLayer;
using Bus.DomainModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusReservationSystem.Controllers
{
    public class CustomerController : Controller
    {
        BusDbContext _db;
        public CustomerController(BusDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var res = _db.Locations.ToList();
            return View(res);
        }

        public IActionResult GetByName(string name)
        {
            var res = _db.Trips.Include(m => m.Bus).Include(m => m.Route).Where(m => m.Route.FromLocation == name).ToList();
            return View(res);
        }

        [Authorize]
        public IActionResult ViewSeats(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.UserName = User.Identity.Name;
                var seat = _db.Trips.Include(m => m.Bus).Include(m => m.Route).Where(m => m.RouteId == id).FirstOrDefault();
                return View(seat);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public IActionResult Seats(int id)
        {
            var seat = _db.Trips.Where(m => m.RouteId == id).FirstOrDefault();
            return View(seat);
        }

        public ActionResult Checkout()
        {
            ViewBag.CheckoutCompleteMessage = "Thank you for booking with us";
            return View();

        }
    }
}