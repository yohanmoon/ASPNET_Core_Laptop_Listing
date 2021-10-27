using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_EShop.Models;

namespace MVC_EShop.Repositories
{
    public interface ILaptopRepository //made interface public
    {
        //TODO 04 created interface
        
        IEnumerable<Laptop> GetLaptops();
        Laptop GetLaptopById(int id);
        void CreateLaptop(Laptop laptop);
        void DeleteLaptop(int id);
        void SaveChanges();
        
    }
}
