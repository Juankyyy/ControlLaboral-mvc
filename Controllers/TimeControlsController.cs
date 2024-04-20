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
        // Agregamos el registro de la entrada
        // Agregamos los detalles de la tabla
        public async Task<IActionResult> Details(int? id)
        {
            return View(await _context.TimeControls.FirstOrDefaultAsync(m => m.Id == id));
        }
        // Agregamos Funcionalidad del boton Registrar entrada
        
        public async Task<IActionResult> RegisterEntry(int id)
        {
            var userId = HttpContext.Session.GetString("UserId");
            var tcontrol = new TimeControl();
            
            tcontrol.DateEntry = DateTime.Now;
            // tcontrol.DateExit = null;
            tcontrol.UserId = Int32.Parse(userId);

            _context.TimeControls.Add(tcontrol);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Employees", new { id = HttpContext.Session.GetString("UserId") });

        }

        // public async Task<IActionResult> RegisterExit(int id)
        // {
        //     var userId = HttpContext.Session.GetString("UserId");


        //     _context.TimeControls.Add(tcontrol);
        //     await _context.SaveChangesAsync();
        //     return RedirectToAction("Details", "Employees", new { id = HttpContext.Session.GetString("UserId") });
        // }

            //Agregamos el apartado de eliminar TimeControl
        public async Task<IActionResult> Delete(TimeControl tcontrol){
            _context.TimeControls.Remove(tcontrol);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}