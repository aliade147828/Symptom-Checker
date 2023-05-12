using DAL.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace WebApplication5.ViewModels
{
    public class AppointmentViewModel
    {
        public string Name { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public string Date { get; set; }
        [Display(Name = "Doctor Name")]
        public string DoctorId { get; set; }
        public string DoctorName { get; set; }
        [ValidateNever]
        public Doctor Doctor { get; set; }

    }
}
