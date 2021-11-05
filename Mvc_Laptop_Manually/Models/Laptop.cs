using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //added
using System.ComponentModel.DataAnnotations.Schema;//Addded

using Microsoft.AspNetCore.Http; //added for iformfile

namespace Mvc_Laptop_Manually.Models
{
    public class Laptop
    {
        //TODO 01 Created class

        public Laptop()
        {

        }

        [Key]
        public int LaptopId { get; set; }

        [ForeignKey("Brand")]
        [Required (ErrorMessage = "Please select a brand.")]
        [Display(Name = "Brand : ")]
        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }

        [Required (ErrorMessage ="Please enter a model.")]
        [Display(Name = "Model : ")]
        public string Model { get; set; }

        [Range(1, 2000)]
        [DataType(DataType.Currency)]
        [Display(Name = "Price : ")]
        public double? Price { get; set; }

        [ForeignKey("ScreenSize")]
        [Display(Name = "Screen Size (inch) : ")]
         public int ScreenSizeId { get; set; }

        public virtual ScreenSize ScreenSize { get; set; }

        [ForeignKey("Resolution")]
        [Display(Name = "Screen resolution: ")]
        [DisplayFormat(DataFormatString = "{0:0.0#}")]
        public int ResolutionId { get; set; }

        public virtual Resolution Resolution { get; set; }


        [ForeignKey("CPU")]
        [Display(Name = "CPU : ")]
        public int CPUId { get; set; }

        public virtual CPU CPU { get; set; }

        [ForeignKey("GPU")]
        [Display(Name = "Graphic Card : ")]
        public int GPUId { get; set; }

        public virtual GPU GPU { get; set; }

        [ForeignKey("RAM")]
        
        [Display(Name = "RAM Memory(GB) : ")]
        public int RAMId { get; set; }

        public virtual RAM RAM { get; set; }

        [Display(Name = "Hard Drive : ")]
        public string HardDrive { get; set; }

        [Range(1, 20)]
        [Display(Name = "Weight(lbs) : ")]
        public double? Weight { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Description : ")]
        public string Description { get; set; }


        //[NotMapped]
        //[Display(Name = "Picture : ")]
        //public IFormFile PhotoAvatar { get; set; }

        //public string ImageName { get; set; }

        //public byte[] PhotoFile { get; set; }

        //public string ImageMimeType { get; set; }


        

       [Display(Name ="Favorite : ")]
        public bool Favorite { get; set; }

        //TODO - adding new field after update-database, add-migration,update-database, update bind attribute in controller
        //TODO - then update index, create,edit,delete views
        [NotMapped]
        [Display(Name ="Logo : ")]
        public IFormFile ImageFile { get; set; }
        public string ImageName { get; internal set; }
    }
}
