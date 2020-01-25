using Microsoft.EntityFrameworkCore;
using timesheet.Models;

namespace timesheet.Data
{
    public class TimesheetDbContext : DbContext
    {
        public DbSet<Timesheet> Timesheets { get; set; }

        public TimesheetDbContext(DbContextOptions<TimesheetDbContext> options)
            : base(options)
        { }
    }
}
