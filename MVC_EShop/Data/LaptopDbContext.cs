using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC_EShop.Models;

    public class LaptopDbContext : DbContext
    {
        public LaptopDbContext (DbContextOptions<LaptopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Laptop> Laptops { get; set; }
    }
