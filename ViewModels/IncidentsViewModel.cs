using DM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DM.ViewModels
{
    public class IncidentsViewModel
    {
        public IEnumerable<Incident> Incidents { get; set; }  // An Enumerable View
        public Incident Incident { get; set; }                // Another View based on Incident Model. Incidents and Incident consist of a Multiple View Model approach

        public int Minor { get; set; }
        public int Major { get; set; }
        public int Critical { get; set; }

        public int Open { get; set; }
        public int InProgress { get; set; }
        public int Resolved { get; set; }
        public int Closed { get; set; }
    }

    // Create ViewModel (returned data to View) based on Controller needs e.g. Incident Edit and List of Incidents are handled by the same Controller (HomeController)
    // IncidentsViewModel.cs -> Therefore, it makes sense to have a common ViewModel (IncidentsViewModel)
    // AccountViewModels.cs  -> An alternative way is to have a class file containing all the View Model classes associated with the same Controller (AccountController)
}