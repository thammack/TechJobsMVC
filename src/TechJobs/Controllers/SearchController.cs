using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;
using System;

namespace TechJobs.Controllers
{
    public class SearchController : TechJobsController
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results
        public IActionResult Search()
        {
            ViewBag.jobs = JobData.FindAll();
            return View();
        }

        public IActionResult Results(string searchType, string searchTerm)
        {
            if (String.IsNullOrWhiteSpace(searchType) || searchType.ToLower() == "all")
            {
                if (String.IsNullOrWhiteSpace(searchTerm)) // if user chose "all" with a wildcard search term.
                {
                    ViewBag.jobs = JobData.FindAll();
                }
                else // else use the search term across all fields.
                {
                    ViewBag.jobs = JobData.FindByValue(searchTerm); 
                }
            }
            else
            {
                if (String.IsNullOrWhiteSpace(searchTerm)) // if the search term is a wild card, return all.
                {
                    ViewBag.jobs = JobData.FindAll();
                }
                else // else search the selected column with the search term.
                {
                    ViewBag.jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                }
               
            }

            // save off variables for the search field to reload.
            AddViewData("SearchType", searchType);
            AddViewData("SearchTerm", searchTerm);
            

            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View("Index");
        }

        private void AddViewData(string name, string value)
        {
            if (ViewData.ContainsKey(name))
            {
                ViewData[name] = value;
            }
            else
            {
                ViewData.Add(name, value);
            }
        }

    }
}
