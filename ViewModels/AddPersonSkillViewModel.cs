using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using timesheet.Models;

namespace timesheet.ViewModels

{
    public class AddPersonSkillViewModel
    {
        public Person Person { get; set; }
        public List<SelectListItem> Skills { get; set; }

        public int PersonID { get; set; }
        public int SkillID { get; set; }

        public AddPersonSkillViewModel() { }

        public AddPersonSkillViewModel(Person person, IEnumerable<Skill> skills)
        {
            Skills = new List<SelectListItem>();

            foreach (var skill in skills)
            {
                Skills.Add(new SelectListItem
                { 
                    Value = skill.ID.ToString(),
                    Text = skill.Name
                });
            }

            Person = person;
        }

    }
}
