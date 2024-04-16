using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;

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
    }
}