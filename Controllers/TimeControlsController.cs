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
            var tcontrol = new TimeControl();
            var userId = HttpContext.Session.GetString("UserId");
            
            tcontrol.DateEntry = DateTime.Now;
            // tcontrol.DateExit = null;
            tcontrol.UserId = Int32.Parse(userId);
            //Arregalr ViewBag
            ViewBag.MessageRegisterEntry =  "Se registró correctamente";

            _context.TimeControls.Add(tcontrol);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Employees");

        }
            //Agregamos el apartadod de eliminar
            public async Task<IActionResult> Delete(TimeControl tcontrol){
                _context.TimeControls.Remove(tcontrol);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Employees");
            }
    }
}