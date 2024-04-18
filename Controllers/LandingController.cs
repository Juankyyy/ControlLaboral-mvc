using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControlLaboral.Controllers
{
    public class LandingController : Controller
    {
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
                return View();
            } else {
                return RedirectToAction("Index");
            }
        }
    }
}