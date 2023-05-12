using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Department
    {
        [Key]
        public int DNO { get; set; }
        [Required]
        public string DName { get; set; }
        [ValidateNever]
        public List<Doctor> Doctors { get; set; }
    }
}
