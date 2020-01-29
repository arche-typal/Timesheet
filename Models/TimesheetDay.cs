using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace timesheet.Models
{
    public class TimesheetDay
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public IList<Timesheet> Timesheets { get; set; }
    }
}
