using System.ComponentModel.DataAnnotations;

namespace JobPortal.ViewModel
{
    public class ListApplicantViewModel
    {
        public string Email;
        [Display(Name = "Resume link")]
        public string ResumeLink;
    }
}