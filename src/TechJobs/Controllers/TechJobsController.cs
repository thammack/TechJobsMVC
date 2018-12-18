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

        public override ViewResult View()
        {
            ViewBag.actions = ActionChoices;
            return base.View();
        }

        public override ViewResult View(string viewName)
        {
            ViewBag.actions = ActionChoices;
            return base.View(viewName);
        }
    }
}