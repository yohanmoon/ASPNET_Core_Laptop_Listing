using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVC_Laptop.Models
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }

        [StringLength(15,MinimumLength =1)]
        public string BrandName { get; set; }

        

        //IQueryable<Brand> PopulateBrandDropDownList
    }
}
