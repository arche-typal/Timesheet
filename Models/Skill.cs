using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace timesheet.Models
{
    public class Skill
    {
        public int ID { get; set; }
        public string Name { get; set; }

        //mant-to-many
        public List<SkillPerson> SkillPersons { get; set; }
    }
}
