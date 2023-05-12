using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Drug
    {
        [Key]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

    }
}
