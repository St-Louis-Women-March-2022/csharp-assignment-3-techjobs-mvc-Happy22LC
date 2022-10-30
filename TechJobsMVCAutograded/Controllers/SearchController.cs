﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVCAutograded.Data;
using TechJobsMVCAutograded.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVCAutograded.Controllers
{
    public class SearchController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }

        // TODO #3 - Create an action method to process a search request and render the updated search views.
        public IActionResult Results(string searchType, string searchTerm)
        {
            List<Job> jobs = new List<Job>();
            if(string.IsNullOrEmpty(searchTerm) || searchTerm == "all" )
            {
                jobs = JobData.FindAll();
                //ViewBag.title = "All Jobs";
            }
            else
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                //ViewBag.title = "Jobs with" + searchType + searchTerm;
            }
            ViewBag.jobs = jobs;
            ViewBag.columns = ListController.ColumnChoices;
            return View("index");
        }
    }
}
