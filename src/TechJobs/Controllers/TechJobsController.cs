using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TechJobs.Controllers
{
    public class TechJobsController : Controller
    {
        private static Dictionary<string, string> ActionChoices = new Dictionary<string, string>() {
            { "search", "Search" },
            { "list", "List" }
        };

        // This is a "static constructor" which can be used
        // to initialize static members of a class
        protected static Dictionary<string, string> ColumnChoices = new Dictionary<string, string>()
        {
            { "core competency", "Skill" },
            { "employer", "Employer" },
            { "location", "Location" },
            { "position type", "Position Type" },
            { "all", "All" }
        };

        public override ViewResult View()
        {
            ViewBag.actions = ActionChoices;
            ViewBag.columns = ColumnChoices;
            return base.View();
        }

        public override ViewResult View(string viewName)
        {
            ViewBag.actions = ActionChoices;
            ViewBag.columns = ColumnChoices;
            return base.View(viewName);
        }
    }
}