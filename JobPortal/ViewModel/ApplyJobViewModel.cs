using System.ComponentModel.DataAnnotations;

namespace JobPortal.ViewModel
{
    public class ApplyJobViewModel
    {
        public string UserId { get; set; }
        public string JobId { get; set; }
        [Url] [Required] 
        [Display(Name = "Resume link")]
        public string ResumeLink { get; set; }
    }
}