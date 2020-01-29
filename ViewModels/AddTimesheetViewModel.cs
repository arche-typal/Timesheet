using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using timesheet.Models;

namespace timesheet.ViewModels
{
    public class AddTimesheetViewModel
    {
        public string Name { get; set; }

        public int DayOfTheWeekID { get; set; }

        public List<SelectListItem> TimesheetDays { get; set; }

        public AddTimesheetViewModel() { }

        public AddTimesheetViewModel(IEnumerable<TimesheetDay> days) {
            TimesheetDays = new List<SelectListItem>();

            foreach (var day in days)
            { 
                TimesheetDays.Add(new SelectListItem
                { 
                    Value = (day.ID).ToString(),
                    Text = day.Name
                });
            }
        }
    }
}
