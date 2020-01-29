using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using timesheet.Data;
using timesheet.Models;
using timesheet.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace timesheet.Controllers
{
    public class TimesheetdayController : Controller
    {
        private readonly TimesheetDbContext context;
        // GET: /<controller>/
        public TimesheetdayController(TimesheetDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            IList<TimesheetDay> days = context.TimesheetDays.ToList();
            return View(days);
        }

        public IActionResult Add()
        {
            AddTimesheetDayViewModel addTimesheetDayViewModel = new AddTimesheetDayViewModel();
            return View(addTimesheetDayViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddTimesheetDayViewModel addTimesheetDayViewModel)
        {
            TimesheetDay newTimesheetDay = new TimesheetDay
            {
                Name = addTimesheetDayViewModel.Name
            };

            context.TimesheetDays.Add(newTimesheetDay);
            context.SaveChanges();

            return Redirect("/");
        }
    }
}
