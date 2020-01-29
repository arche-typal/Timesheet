using Microsoft.EntityFrameworkCore;
using timesheet.Models;

namespace timesheet.Data
{
    public class TimesheetDbContext : DbContext
    {
        public DbSet<Timesheet> Timesheets { get; set; }
        public DbSet<TimesheetDay> TimesheetDays { get; set; }

        //many-to-many
        public DbSet<Person> Persons { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillPerson> SkillPersonSet { get; set; }


        public TimesheetDbContext(DbContextOptions options)
            : base(options)
        { }


        //many-to-many OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SkillPerson>()
                .HasKey(c => new { c.SkillID, c.PersonID });
        }
        //public TimesheetDbContext()
        //{ }
    }
}
