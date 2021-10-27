using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //added
using System.ComponentModel.DataAnnotations.Schema;//Addded
using MVC_EShop.Controllers;
using Microsoft.AspNetCore.Http; //added for iformfile

namespace MVC_EShop.Models
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
        public LaptopBrand? Brand { get; set; }
        
        [Required]
        [Display(Name = "Model : ")]
        public string Model { get; set; }

        [Range(1,2000)]
        [DataType(DataType.Currency)]
        [Display(Name = "Price : ")]
        public double? Price { get; set; }

        [Range(1,30)]
        [Display(Name = "Screen Size : ")]
        public double? ScreenSize { get; set; }

        [Display(Name = "Screen resolution: ")]
        public string ScreenResolution { get; set; }

        [Display(Name = "CPU : ")]
        public string CPU { get; set; }

        [Display(Name = "Graphic Card : ")]
        public string GraphicCard { get; set; }

        [Range(1,500)]
        [Display(Name = "RAM Memory(GB) : ")]
        public int RAM { get; set; }

        [Display(Name = "Hard Drive : ")]
        public string HardDrive { get; set; }

        [Range(1,20)]
        [Display(Name = "Weight(lbs) : ")]
        public double? Weight { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name ="Description : ")]
        public string Description { get; set; }


        [NotMapped]
        [Display(Name = "Laptop Picture:")]
        public IFormFile PhotoAvatar { get; set; }

        public string ImageName { get; set; }

        public byte[] PhotoFile { get; set; }

        public string ImageMimeType { get; set; }

    }
}
