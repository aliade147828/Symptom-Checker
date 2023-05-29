using System.ComponentModel.DataAnnotations;

namespace WebApplication5.ViewModels
{
    public class DepartmentViewModel
    {
        public int DNO { get; set; }
        [Required(ErrorMessage = "Department Name Is Required")]
        public string Name { get; set; }
    }
}
