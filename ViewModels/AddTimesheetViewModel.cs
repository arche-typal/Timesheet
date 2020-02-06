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


        /*public constructorForThisViewModel(IEnumerable<ObjectYoureEnumeratingThrough> objectNickname)
         {
            //using constructor to assign value to field that is of type List.
            ListReferencedAbove = new List<SelectListItem>();

            //iterate through each value in parameter of constructor that is from 
            //"context.TimesheetDays.ToList();" 
            foreach (var nickname in nicknameList)
            {
                //add each value from "context.TimesheetDays.ToList();" to ListReferencedAbove in class
                //ListReferencedAbove.Add(new SelectListItem{Value=(nickname.ID).ToString(),Text=nickname.Name});
                //also formatted this way:
                ListReferencedAbove.Add(new SelectListItem
                {
                    Value=(nickname.ID).ToString(),
                    Text=nickname.Name
                });
            }

         }

        //ALL OF THIS is done/instantiated within the controller and then passed into View();
        //This one is passed into the "Add" view template for the TimesheetController.
        //Boom.
        //See below for constructor that was just explained above.
        */
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
