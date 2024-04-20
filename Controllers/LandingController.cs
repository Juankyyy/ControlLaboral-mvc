using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControlLaboral.Data;

namespace ControlLaboral.Controllers
{
    public class LandingController : Controller
    {
        public readonly ControlLaboralContext _context;
        public LandingController(ControlLaboralContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Job") == "Admin")
            {
                return RedirectToAction("Admin");
            } else {
                return View();
            }
        }

        public IActionResult Admin()
        {
            if (HttpContext.Session.GetString("Job") == "Admin")
            {
                var employee = _context.Employees.Find(Int32.Parse(HttpContext.Session.GetString("UserId")));

                ViewBag.Admin = employee.Names;

                return View();
            } else {
                return RedirectToAction("Index");
            }
        }
    }
}