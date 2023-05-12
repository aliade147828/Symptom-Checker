using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SymptomChecker.Models
{
    public class CreateViewModel
    {

        [Required]
        public string UserName { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfrimPassword { get; set; }
        [Required]
        public string Location { get; set; }
        public byte[] Photo { get; set; }
        [Required]
        public int WorkingHours { get; set; }
        public int DNO { get; set; }

    }
}
