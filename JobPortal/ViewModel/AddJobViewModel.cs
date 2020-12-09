using System.ComponentModel.DataAnnotations;

namespace JobPortal.ViewModel
{
    public class AddJobViewModel
    {
        [Required] public bool Active { get; set; }
        [Required] public string Location { get; set; }
        [Required] public string Company { get; set; }
        
        [Required(ErrorMessage = "Salary is required.")]
        [DataType(DataType.Currency)]
        
        public double Salary { get; set; }
        [Display(Name = "Tools and technology")]
        [Required] public string ToolsAndTechnologies { get; set; }
    }
}