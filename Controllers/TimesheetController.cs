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
    public class TimesheetController : Controller
    {

        private TimesheetDbContext context;
        public TimesheetController(TimesheetDbContext dbContext)
        {
            context = dbContext;
        }
        
        // GET: /<controller>/
        public IActionResult Index()
        {
            IList<Timesheet> timesheets = context.Timesheets.ToList();
            return View(timesheets);
        }

        public IActionResult Add()
        {
            AddTimesheetViewModel addTimesheetViewModel = new AddTimesheetViewModel();
            return View(addTimesheetViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddTimesheetViewModel addTimesheetViewModel)
        {
            Timesheet newTimesheet = new Timesheet
            {
                Name = addTimesheetViewModel.Name,
            };

            context.Timesheets.Add(newTimesheet);
            context.SaveChanges();

            return Redirect("/Timesheet");
        }
    }
}
