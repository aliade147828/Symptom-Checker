using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace WebApplication5.ViewModels
{
    public class RequestViewModel
    {
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string? FileName { get; set; }
        public string Status { get; set; }

        [ValidateNever]
        public IFormFile CV { get; set; }
        [ValidateNever]
        public bool IsApproved { get; set; }
    }
}
