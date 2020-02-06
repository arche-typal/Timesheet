using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace timesheet.Models
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        
        //many-to-many
        //public string Skill { get; set; }

        public IList<SkillPerson> SkillPersons { get; set; }

        public Person()
        { 
        
        }

    }
}
