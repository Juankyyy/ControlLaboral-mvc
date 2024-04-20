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
            if (HttpContext.Session.GetString("Job") == "Admin")
            {
                return View(await _context.Employees.ToListAsync());
            } else {
                return RedirectToAction("Details", new { id = HttpContext.Session.GetString("UserId") });
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            var employee = _context.Employees.Find(id);
            ViewBag.employeeName = employee.Names;
            return View(employee);
        }

        public async Task<IActionResult> Delete(Employee employee) //Agregar Vista de borrar o un modal
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //En este apartado usamos el crear para registar
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserId") != null)
            {
                if (HttpContext.Session.GetString("Job") == "Admin")
                {
                    return RedirectToAction("Admin", "Landing");
                } else {
                    return RedirectToAction("Details", new { id = HttpContext.Session.GetString("UserId") });
                }
            } else {
                return View();
            }
        }

        
        public IActionResult LoginCheck(string email, string password)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Email == email && e.Password == password);

            if (employee != null)
            {
                HttpContext.Session.SetString("Job", employee.Job);
                HttpContext.Session.SetString("UserId", employee.Id.ToString());
                
                var admin = HttpContext.Session.GetString("Job");

                if (admin == "Admin")
                {
                    return RedirectToAction("Admin", "Landing");
                } else {
                    return RedirectToAction("Details", new { id = employee.Id });
                }

            } else {
                ViewBag.Danger = "Ingresa un correo o contraseña correctos";
            }

            return View("Login");
        }

        public IActionResult SignOut()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Landing");
        }
    }
}