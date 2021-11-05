using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Mvc_Laptop_Manually.Models;

namespace Mvc_Laptop_Manually.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        //TODO ADDED DbSet
        public virtual DbSet<Laptop> Laptops { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<CPU> CPUs { get; set; }
        public virtual DbSet<GPU> GPUs { get; set; }
        public virtual DbSet<RAM> RAMs { get; set; }
        public virtual DbSet<Resolution> Resolutions { get; set; }
        public virtual DbSet<ScreenSize> ScreenSizes { get; set; }







    }
}
