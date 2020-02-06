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
    public class SkillController : Controller
    {
        private TimesheetDbContext context;
        public SkillController(TimesheetDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            //no index.cshtml yet
            IList<Skill> skills = context.Skills.ToList();
            return View(skills);
        }

        public IActionResult Add()
        {
            AddSkillViewModel addSkillViewModel = new AddSkillViewModel();
            return View(addSkillViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddSkillViewModel addSkillViewModel)
        {
            Skill newSkill = new Skill
            {
                Name = addSkillViewModel.Name
            };

            context.Skills.Add(newSkill);
            context.SaveChanges();

            return Redirect("/");
        }

        public IActionResult Remove()
        {
            ViewBag.skills = context.Skills.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] skillIds)
        {
            foreach (int skil in skillIds)
            {
                context.Skills.Remove(context.Skills.Single(sk => sk.ID == skil));
            }

            context.SaveChanges();
            return Redirect("/Skill/Index");
        }
    }
}
