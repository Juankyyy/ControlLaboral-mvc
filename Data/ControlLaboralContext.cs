using Microsoft.EntityFrameworkCore;
using ControlLaboral.Models;

namespace ControlLaboral.Data
{
    public class ControlLaboralContext : DbContext
    {
        public ControlLaboralContext(DbContextOptions<ControlLaboralContext> options) : base(options)
        {

        }
            //Modelo de la tabla empleados
        public DbSet<Employee> Employees { get; set; }

        //Agregar el modelo de la tabla TimeControl
        //public DbSet<TimeControl> TimeControls {get; set; }
    }
}