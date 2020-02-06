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
        

    public class PersonController : Controller
    {
        
        private readonly TimesheetDbContext context;

        public PersonController(TimesheetDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            IList<Person> persons = context.Persons.ToList();
            return View(persons);
        }

        public IActionResult Add()
        { 
            AddPersonViewModel addPersonViewModel = new AddPersonViewModel();
            //Add
            return View(addPersonViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddPersonViewModel addPersonViewModel)
        {
            Person newPerson = new Person
            {
                Name = addPersonViewModel.Name
            };

            context.Persons.Add(newPerson);
            context.SaveChanges();

            return Redirect("/Person/ViewPerson/" + newPerson.ID);        
                
            }

        public IActionResult ViewPerson(int id)
        {
            //list skills
            List<SkillPerson> skills = context
                .SkillPersonSet
                .Include(skill => skill.Skill)
                .Where(sp => sp.PersonID == id)
                .ToList();

            //Create Person
            Person person = context.Persons.Single(m => m.ID == id);

            ViewPersonViewModel viewModel = new ViewPersonViewModel {
                Skills = skills,
                Person = person
            };

            return View(viewModel);
        }

        public IActionResult AddItem(int id)
        {
            /*Grab individual Person instance from db
            this is the Person instance we'll be adding
            skills to.*/
            Person person = context.Persons.Single(p => p.ID == id);

            /*Generate list of Skill objects currently in db
            These will be passed into the view to be displayed
            in a select option tag
            */
            List<Skill> skills = context.Skills.ToList();
            return View(new AddPersonSkillViewModel(person, skills));
        }

        [HttpPost]
        public IActionResult AddItem(AddPersonSkillViewModel addPersonSkillViewModel)
        {
            //ModelState.IsValid
            var skillID = addPersonSkillViewModel.SkillID;
            var personID = addPersonSkillViewModel.PersonID;

            IList<SkillPerson> skillPeople = context.SkillPersonSet
                .Where(sp => sp.SkillID == skillID)
                .Where(sp => sp.PersonID == personID).ToList();
            if (skillPeople.Count == 0)
            {
                SkillPerson personItem = new SkillPerson
                {
                    SkillID = skillID,
                    PersonID = personID
                };

                context.SkillPersonSet.Add(personItem);
                context.SaveChanges();
            }

            return Redirect(string.Format("/Person/ViewPerson/{0}", addPersonSkillViewModel.PersonID));
        }

        //REMOVE

        public IActionResult Remove()
        {
            ViewBag.persons = context.Persons.ToList();
            return View();
        }


        //"personIds" matches name attribute of checkbox input html tag in /Person/Remove.cshtml
        [HttpPost]
        public IActionResult Remove(int[] personIds)
        {
            foreach (int person in personIds)
            {
                context.Persons.Remove(context.Persons.Single(p => p.ID == person));
            }

            context.SaveChanges();
            return Redirect("/");
        }

        
    }
}
