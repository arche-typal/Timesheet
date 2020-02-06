using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            //IList<Timesheet> timesheets = context.Timesheets.ToList();
            IList<Timesheet> timesheets = context.Timesheets.Include(c => c.DayOfTheWeek).ToList();
            return View(timesheets);
        }

        public IActionResult Add()
        {
            //AddTimesheetViewModel addTimesheetViewModel = new AddTimesheetViewModel();
            AddTimesheetViewModel addTimesheetViewModel = new AddTimesheetViewModel(context.TimesheetDays.ToList());
            return View(addTimesheetViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddTimesheetViewModel addTimesheetViewModel)
        {
            TimesheetDay newTimesheetDay = 
                context.TimesheetDays.Single(c => c.ID == addTimesheetViewModel.DayOfTheWeekID);
                //context.TimesheetDays.
            
            Timesheet newTimesheet = new Timesheet 
            {            
                Name = addTimesheetViewModel.Name,
                DayOfTheWeek = newTimesheetDay
            };

            context.Timesheets.Add(newTimesheet);
            context.SaveChanges();

            return Redirect("/Timesheet");
        }


        public IActionResult Remove()
        {
            ViewBag.timesheets = context.Timesheets.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] timesheetIds)
        {
            foreach (int timesheetId in timesheetIds)
            {
                //context.Timesheets.Remove(timesheet);
                //Timesheet aTimesheet = context.Timesheets.Single(t => t.ID == timesheetId);
                //context.Timesheets.Remove(aTimesheet);

                context.Timesheets.Remove(context.Timesheets.Single(t => t.ID == timesheetId));
            }

            context.SaveChanges();
            return Redirect("/Timesheet/Index");
        }

        public IActionResult Edit(int timesheetId)
        {
            Timesheet timesheet = context.Timesheets.Single(t => t.ID == timesheetId);

            return View(timesheet);
        }
        
        [HttpPost]
        public IActionResult Edit(int timesheetId, string name)


    }

}
