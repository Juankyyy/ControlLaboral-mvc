using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControlLaboral.Data;
using ControlLaboral.Models;

namespace ControlLaboral.Controllers
{
    public class TimeControlsController : Controller
    {
        public readonly ControlLaboralContext _context;
        public TimeControlsController(ControlLaboralContext context)
        {
            _context = context;
        }

        //Apartado para mostar la tabla de empleados 
        public async Task<IActionResult> Index()
        {
            return View(await _context.TimeControls.ToListAsync());
        }
        //Agregamos el registro de la entrada
        

    }
}