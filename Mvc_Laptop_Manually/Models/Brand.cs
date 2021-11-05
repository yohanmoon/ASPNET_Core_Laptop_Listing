using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Mvc_Laptop_Manually.Models
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }

        [Required]
        [StringLength(15,MinimumLength =1)]
        public string Name { get; set; }

        

        //IQueryable<Brand> PopulateBrandDropDownList
    }
}
