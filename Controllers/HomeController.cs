using DM.Models;
using DM.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DM.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        /// <summary>
        /// Controller -> Load Incidents List in Table View (GET)
        /// </summary>
        /// <param name="page"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index(int page = 1, string search = "")
        {
            IEnumerable<Incident> incidents = null;
            IEnumerable<Incident> incidentsFiltered = null;

            if (page < 1)
                page = 1;

            // Catch SqlException or any Exception e.g. Database connection Error etc
            try
            {
                int pageSize = 10;
                int excludeEntries = (pageSize * page) - pageSize;

                if (search != "")
                {
                    incidentsFiltered = _context.Incidents
                                                .Where(s => s.Title.Contains(search.ToLower()));

                    var temp = incidentsFiltered.ToList();
                }
                else
                {
                    incidentsFiltered = _context.Incidents;
                }

                // Paging
                incidents = incidentsFiltered
                                    .OrderBy(i => i.Id)
                                    .Skip(excludeEntries)
                                    .Take(pageSize);

            }
            catch (Exception)
            {
                // Handled in View over the Model == null
            }

            if (incidents != null)
            {
                var pageIncidents = new IncidentsViewModel()
                {
                    Incidents = incidents,
                    Minor = incidentsFiltered.ToList().FindAll(incident => incident.Severity == Severity.Minor).Count(),
                    Major = incidentsFiltered.ToList().FindAll(incident => incident.Severity == Severity.Major).Count(),
                    Critical = incidentsFiltered.ToList().FindAll(incident => incident.Severity == Severity.Critical).Count(),
                    Open = incidentsFiltered.ToList().FindAll(incident => incident.Status == Status.Open).Count(),
                    InProgress = incidentsFiltered.ToList().FindAll(incident => incident.Status == Status.InProgress).Count(),
                    Resolved = incidentsFiltered.ToList().FindAll(incident => incident.Status == Status.Resolved).Count(),
                    Closed = incidentsFiltered.ToList().FindAll(incident => incident.Status == Status.Closed).Count()
                };

                ViewData["page"] = page;
                ViewData["search"] = search;

                return View(pageIncidents);
            }

            return View();
        }

        /// <summary>
        /// Controller -> Load Modal Edit Form (GET)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var incident = _context.Incidents.SingleOrDefault(i => i.Id == id);

            if (incident == null)
                return HttpNotFound();

            var viewModel = new IncidentsViewModel();

            viewModel.Incident = new Incident
            {
                Id = incident.Id,                       // Created automatically in Database
                Name = incident.Name,
                Title = incident.Title,
                Severity = incident.Severity,
                Status = incident.Status
            };

            return PartialView(viewModel);
        }

        /// <summary>
        /// Controller -> Modal Edit Form -> Save (POST)
        /// </summary>
        /// <param name="incident"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Incident incident)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new IncidentsViewModel
                {
                    Incident = incident
                };

                return View("Edit", viewModel);
            }

            if (incident.Id == 0)
            {
                var lastItemInDb = _context.Incidents.ToList().Last();
                int num = Convert.ToInt32(lastItemInDb.Name.Replace("PR-", ""));
                num += 1;
                incident.Name = "PR-" + num;
                _context.Incidents.Add(incident);                                       // Add New Incident
            }
            else if (Request.Form["delete"] == "true")
            {
                var incidentInDb = _context.Incidents.Single(c => c.Id == incident.Id);
                _context.Incidents.Remove(incidentInDb);                                // Delete Incident
            }
            else
            {
                var incidentInDb = _context.Incidents.Single(c => c.Id == incident.Id); // Edit Incident
                incidentInDb.Title = incident.Title;
                incidentInDb.Severity = incident.Severity;
                incidentInDb.Status = incident.Status;
            }

            _context.SaveChanges();                                                     // Update Database due to e.g. Add, Delete or Modify

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// About the ASP.NET Application
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            return View();
        }

        /// <summary>
        /// Contact Information
        /// </summary>
        /// <returns></returns>
        public ActionResult Contact()
        {
            return View();
        }
    }
}