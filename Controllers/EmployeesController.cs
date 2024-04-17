using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControlLaboral.Data;
using ControlLaboral.Models;

namespace ControlLaboral.Controllers
{
    public class EmployeesController : Controller
    {
        public readonly ControlLaboralContext _context;
        public EmployeesController(ControlLaboralContext context)
        {
            _context = context;
        }

        //Apartado para mostar la tabla de empleados 
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());
        }

        public IActionResult Login()
        {
            return View();
        }

        
        public IActionResult LoginVerificar(string email, string password)
        {
            var employees = _context.Employees.AsQueryable();


            if (employees.Any(e => e.Email == email && e.Password == password))
            {
                return RedirectToAction("Index", "Employees");
            } else {
                ViewBag.Danger = "Ingresa un correo o contraseña correctos";
            }

            return View("Login");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Employee employee)
        {
            await _context.Employees
        }
    }
}