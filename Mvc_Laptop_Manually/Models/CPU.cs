using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Mvc_Laptop_Manually.Models
{
    public class CPU
    {
        [Key]
        public int CPUId { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 1)]
        public string Name { get; set; }

    }
}
