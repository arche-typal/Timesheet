using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace timesheet.Models
{
    public class SkillPerson
    {
        public int SkillID { get; set; }
        public Skill Skill { get; set; }

        public int PersonID { get; set; }
        public Person Person { get; set; }
    }
}
