using DAL.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplication5.ViewModels
{
    public class AppoinmentViewModel
    {
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Phone Number")]
        [Required]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public string Date { get; set; }
        public string? Time { get; set; }

        [Display(Name = "Doctor Name")]
        public string DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string Status { get; set; }
        //[ValidateNever]
        //[JsonIgnore]
        //public Doctor Doctor { get; set; }

    }
}
