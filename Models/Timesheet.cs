using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace timesheet.Models
{
    public class Timesheet
    {
        public string Name { get; set; }
        public int ID { get; set; }

        //one-to-many
        public int DayOfTheWeekID { get; set; }
        public TimesheetDay DayOfTheWeek { get; set; }

    }
}
