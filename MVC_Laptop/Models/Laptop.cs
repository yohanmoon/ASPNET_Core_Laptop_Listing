using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //added
using System.ComponentModel.DataAnnotations.Schema;//Addded

using Microsoft.AspNetCore.Http; //added for iformfile

namespace MVC_Laptop.Models
{
    public class Laptop
    {
        //TODO 01 Created class

        public Laptop()
        {

        }

        [Key]
        public int LaptopId { get; set; }

        [Required]
        [Display(Name = "Brand : ")]
        public BrandType Brand { get; set; }

        [Required]
        [Display(Name = "Model : ")]
        public string Model { get; set; }

        [Range(1, 2000)]
        [DataType(DataType.Currency)]
        [Display(Name = "Price : ")]
        public double? Price { get; set; }

        [Range(1, 30)]
        [Display(Name = "Screen Size (inch) : ")]
        [DisplayFormat(DataFormatString ="{0:0.0#}")]
        public double? ScreenSize { get; set; }

        [Display(Name = "Screen resolution: ")]
        public string ScreenResolution { get; set; }

        [Display(Name = "CPU : ")]
        public string CPU { get; set; }

        [Display(Name = "Graphic Card : ")]
        public string GraphicCard { get; set; }

        [Range(1, 500)]
        [Display(Name = "RAM Memory(GB) : ")]
        public int? RAM { get; set; }

        [Display(Name = "Hard Drive : ")]
        public string HardDrive { get; set; }

        [Range(1, 20)]
        [Display(Name = "Weight(lbs) : ")]
        public double? Weight { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Description : ")]
        public string Description { get; set; }


        [NotMapped]
        [Display(Name = "Picture : ")]
        public IFormFile PhotoAvatar { get; set; }

        public string ImageName { get; set; }

        public byte[] PhotoFile { get; set; }

        public string ImageMimeType { get; set; }


        

       [Display(Name ="Favorite : ")]
        public bool Favorite { get; set; }

        //TODO - adding new field after update-database, add-migration,update-database, update bind attribute in controller
        //TODO - then update index, create,edit,delete views
        [DataType(DataType.ImageUrl)]
        [Display(Name ="Image : ")]
        public string ImageUrl { get; set; }
    }
}
