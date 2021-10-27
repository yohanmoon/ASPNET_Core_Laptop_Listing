using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//added below assemblies
using System.IO;
using MVC_EShop.Models;
using Microsoft.EntityFrameworkCore;


namespace MVC_EShop.Repositories
{
    public class LaptopRepository : ILaptopRepository //inherited interface
    {
        //TODO 05 Created Repository and inherited interface, To retrieve and store data
        private LaptopDbContext _context;

        public LaptopRepository(LaptopDbContext context)

        {
            _context = context;
        }
        public void CreateLaptop(Laptop laptop)
        {
            if(laptop.PhotoAvatar != null && laptop.PhotoAvatar.Length >0)
            {
                laptop.ImageMimeType = laptop.PhotoAvatar.ContentType;
                laptop.ImageName = Path.GetFileName(laptop.PhotoAvatar.FileName);

                using( var memoryStream = new MemoryStream())
                {
                    laptop.PhotoAvatar.CopyTo(memoryStream);
                    laptop.PhotoFile = memoryStream.ToArray();
                }
                _context.Add(laptop);
                _context.SaveChanges();
            }
        }

        public void DeleteLaptop(int id)
        {
            var laptop = _context.Laptops.SingleOrDefault(a => a.LaptopId == id);
            _context.Laptops.Remove(laptop);
            _context.SaveChanges();
        }

        public Laptop GetLaptopById(int id)
        {
            return _context.Laptops.Include(l => l.Brand)
                .SingleOrDefault(m => m.LaptopId == id);
        }

        public IEnumerable<Laptop> GetLaptops()
        {
            return _context.Laptops.ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
