using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IM.Models
{
    public enum Severity
    {
        [Display(Name = "Minor")]
        Minor = 0,
        [Display(Name = "Major")]
        Major = 1,
        [Display(Name = "Critical")]
        Critical = 2
    }

    public enum Status
    {
        [Display(Name = "Open")]
        Open = 0,
        [Display(Name = "In Progress")]
        InProgress = 1,
        [Display(Name = "Resolved")]
        Resolved = 2,
        [Display(Name = "Closed")]
        Closed = 3
    }

    public class Incident
    {
        public int Id { get; set; }

        [Display(Name = "ID")]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required] 
        [Display(Name = "Severity")]
        public Severity Severity { get; set; }

        [Required]
        [Display(Name = "Status")]
        public Status Status { get; set; }

        // ErrorMessage in Required Fields can be overriden e.g. Required(ErrorMessage = "Error. Please enter text")
    }
}