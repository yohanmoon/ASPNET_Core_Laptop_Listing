using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering; //auto added
using Microsoft.EntityFrameworkCore; //auto added
using MVC_EShop.Models;
//adding
using Microsoft.AspNetCore.Hosting;
using MVC_EShop.Repositories;


namespace MVC_EShop.Controllers
{
    public class LaptopsController : Controller
    {
        //TODO 06 Updated controller to use repository

        private ILaptopRepository _repository;
        private IWebHostEnvironment _environment;
        public LaptopsController(ILaptopRepository repository, IWebHostEnvironment environment)
        {
            _repository = repository;
            _environment = environment;
        }


        //private readonly LaptopDbContext _context;

        //public LaptopsController(LaptopDbContext context)
        //{
        //    _context = context;
        //}

        // GET: Laptops
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Laptops.ToListAsync());
        //}

        //GET: Laptops
        public IActionResult Index()
        {
            return View( _repository.GetLaptops());
        }

        //// GET: Laptops/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var laptop = await _context.Laptops
        //        .FirstOrDefaultAsync(m => m.LaptopId == id);
        //    if (laptop == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(laptop);
        //}

        // GET: Laptops/Details/5
        public IActionResult Details(int id)
        {
           

            var laptop = _repository.GetLaptopById(id);
            if (laptop == null)
            {
                return NotFound();
            }

            return View(laptop);
        }

        // GET: Laptops/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Laptops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("LaptopId,Brand,Model,Price,ScreenSize,ScreenResolution,CPU,GraphicCard,RAM,HardDrive,Weight,Description,ImageName,PhotoFile,ImageMimeType")] Laptop laptop)
        //{
        //    if (ModelState.IsValid)
        //    {


        //        _context.Add(laptop);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(laptop);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( Laptop laptop)
        {
            if (ModelState.IsValid)
            {


                _repository.CreateLaptop(laptop);
                
                return RedirectToAction(nameof(Index));
            }
            return View(laptop);
        }


        // GET: Laptops/Edit/5
        //[HttpGet]
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var laptop = await _context.Laptops.FindAsync(id);
        //    if (laptop == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(laptop);
        //}

        [HttpGet]
        public IActionResult Edit(int id)
        {


            var laptop = _repository.GetLaptopById(id);
            if (laptop == null)
            {
                return NotFound();
            }
            return View(laptop);
        }


        // POST: Laptops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("LaptopId,Brand,Model,Price,ScreenSize,ScreenResolution,CPU,GraphicCard,RAM,HardDrive,Weight,Description,ImageName,PhotoFile,ImageMimeType")] Laptop laptop)
        //{
        //    if (id != laptop.LaptopId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(laptop);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!LaptopExists(laptop.LaptopId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(laptop);
        //}

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Laptop laptop)
        {
            var laptopToUpdate = _repository.GetLaptopById(id);
            bool isUpdated = await TryUpdateModelAsync<Laptop>(
                laptopToUpdate,
                "",
                c => c.Brand,
                c => c.Model,
                c => c.Price,
                c => c.ScreenSize,
                c => c.ScreenResolution,
                c => c.CPU,
                c => c.GraphicCard,
                c => c.RAM,
                c => c.HardDrive,
                c => c.Weight,
                c => c.Description);

            if (isUpdated)
            {
                _repository.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(laptopToUpdate);
        }


        // GET: Laptops/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {

            var laptop = _repository.GetLaptopById(id);
            if (laptop == null)
            {
                return NotFound();
            }

            return View(laptop);
        }

        // POST: Laptops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {

            _repository.DeleteLaptop(id);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
