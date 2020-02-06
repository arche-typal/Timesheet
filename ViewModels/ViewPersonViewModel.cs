using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using timesheet.Models;

namespace timesheet.ViewModels
{
    public class ViewPersonViewModel
    {
        public IList<SkillPerson> Skills { get; set; }
        public Person Person { get; set; }
    }
}
