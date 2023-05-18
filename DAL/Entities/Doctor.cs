using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Doctor : IdentityUser
    {
        public byte[] profilePic { get; set; }
        public string? Location { get; set; }

        public int? WorkingHours { get; set; }
        public int? DNO { get; set; }
        [ValidateNever]
        [ForeignKey("DNO")]
        public Department? Department { get; set; }
        [ValidateNever]
        public ICollection<Appoinment>? Appoinment { get; set; }
    }
}
