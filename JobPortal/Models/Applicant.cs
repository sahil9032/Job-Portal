using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace JobPortal.Models
{
    public class Applicant
    {
        [ForeignKey("IdentityUser")] public string UserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
        [ForeignKey("Jobs")] public string JobId { get; set; }

        public Jobs Jobs { get; set; }

        [Url] public string ResumeLink { get; set; }
    }
}