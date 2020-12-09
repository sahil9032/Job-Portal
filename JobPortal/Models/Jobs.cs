using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace JobPortal.Models
{
    public class Jobs
    {
        [Key] public string JobId { get; set; }
        [Required] public bool Active { get; set; }
        [Required] public string Location { get; set; }
        [Required] public string Company { get; set; }
        
        [Required]
        [DataType(DataType.Currency)]
        public double Salary { get; set; }

        [Required] public string ToolsAndTechnologies { get; set; }
        
        [ForeignKey("IdentityUser")]
        public string ProviderId { get; set; }
        public IdentityUser IdentityUser { get; set; }
        
        public List<Applicant> Applicants { get; set; }
    }
}