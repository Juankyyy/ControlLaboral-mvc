using Microsoft.EntityFrameworkCore;
using ControlLaboral.Models;

namespace ControlLaboral.Data
{
    public class ControlLaboralContext : DbContext
    {
        public ControlLaboralContext(DbContextOptions<ControlLaboralContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<TimeControl> TimeControls {get; set; }
    }
}