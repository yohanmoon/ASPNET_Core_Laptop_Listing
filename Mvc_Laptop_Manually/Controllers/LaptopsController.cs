using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mvc_Laptop_Manually.Data;

namespace Mvc_Laptop_Manually.Models
{
    public class LaptopsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        //TODO IFile added iwebhostenvironment
        public LaptopsController(ApplicationDbContext context ,IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment ;
        }

        // GET: Laptops
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Laptops.Include(l => l.Brand).Include(l => l.CPU).Include(l => l.GPU).Include(l => l.RAM).Include(l => l.Resolution).Include(l => l.ScreenSize);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Laptops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laptop = await _context.Laptops
                .Include(l => l.Brand)
                .Include(l => l.CPU)
                .Include(l => l.GPU)
                .Include(l => l.RAM)
                .Include(l => l.Resolution)
                .Include(l => l.ScreenSize)
                .FirstOrDefaultAsync(m => m.LaptopId == id);
            if (laptop == null)
            {
                return NotFound();
            }

            return View(laptop);
        }

        // GET: Laptops/Create
        public IActionResult Create()
        {
            
            //TODO - added orderby(n=>n.name to sort alphabetically)
            ViewData["BrandId"] = new SelectList(_context.Brands.OrderBy(n=>n.Name), "BrandId", "Name");
            ViewData["CPUId"] = new SelectList(_context.CPUs.OrderBy(n => n.Name), "CPUId", "Name");
            ViewData["GPUId"] = new SelectList(_context.GPUs.OrderBy(n => n.Name), "GPUId", "Name");
            ViewData["RAMId"] = new SelectList(_context.RAMs.OrderBy(n => n.Name), "RAMId", "Name");
            ViewData["ResolutionId"] = new SelectList(_context.Resolutions.OrderBy (n => n.Name), "ResolutionId", "Name");
            ViewData["ScreenSizeId"] = new SelectList(_context.ScreenSizes.OrderBy(n => n.Name), "ScreenSizeId", "Name");
            return View();
        }

        // POST: Laptops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LaptopId,BrandId,Model,Price,ScreenSizeId,ResolutionId,CPUId,GPUId,RAMId,HardDrive,Weight,Description,Favorite,ImageFile")] Laptop laptop)
        {
            if (ModelState.IsValid)
            {
                //TODO IFILE- made image folder under wwwroot
                //Save image to wwwroot/image
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(laptop.ImageFile.FileName);
                string extension = Path.GetExtension(laptop.ImageFile.FileName); //extension just in case same name file exists
                laptop.ImageName = fileName = fileName + DateTime.Now.ToString("yymmss") + extension;
                string path = Path.Combine(wwwRootPath + "/Image/", fileName); //location to save
                using(var fileStream = new FileStream(path, FileMode.Create))
                {
                    await laptop.ImageFile.CopyToAsync(fileStream);
                }
                //insert record


                _context.Add(laptop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "Name", laptop.BrandId);
            ViewData["CPUId"] = new SelectList(_context.CPUs, "CPUId", "Name", laptop.CPUId);
            ViewData["GPUId"] = new SelectList(_context.GPUs, "GPUId", "Name", laptop.GPUId);
            ViewData["RAMId"] = new SelectList(_context.RAMs, "RAMId", "Name", laptop.RAMId);
            ViewData["ResolutionId"] = new SelectList(_context.Resolutions, "ResolutionId", "Name", laptop.ResolutionId);
            ViewData["ScreenSizeId"] = new SelectList(_context.ScreenSizes, "ScreenSizeId", "Name", laptop.ScreenSizeId);
            return View(laptop);
        }

        // GET: Laptops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laptop = await _context.Laptops.FindAsync(id);
            if (laptop == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "Name", laptop.BrandId);
            ViewData["CPUId"] = new SelectList(_context.CPUs, "CPUId", "Name", laptop.CPUId);
            ViewData["GPUId"] = new SelectList(_context.GPUs, "GPUId", "Name", laptop.GPUId);
            ViewData["RAMId"] = new SelectList(_context.RAMs, "RAMId", "Name", laptop.RAMId);
            ViewData["ResolutionId"] = new SelectList(_context.Resolutions, "ResolutionId", "Name", laptop.ResolutionId);
            ViewData["ScreenSizeId"] = new SelectList(_context.ScreenSizes, "ScreenSizeId", "Name", laptop.ScreenSizeId);
            return View(laptop);
        }

        // POST: Laptops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LaptopId,BrandId,Model,Price,ScreenSizeId,ResolutionId,CPUId,GPUId,RAMId,HardDrive,Weight,Description,Favorite,ImageUrl")] Laptop laptop)
        {
            if (id != laptop.LaptopId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    

                    _context.Update(laptop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LaptopExists(laptop.LaptopId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
                
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "Name", laptop.BrandId);
            ViewData["CPUId"] = new SelectList(_context.CPUs, "CPUId", "Name", laptop.CPUId);
            ViewData["GPUId"] = new SelectList(_context.GPUs, "GPUId", "Name", laptop.GPUId);
            ViewData["RAMId"] = new SelectList(_context.RAMs, "RAMId", "Name", laptop.RAMId);
            ViewData["ResolutionId"] = new SelectList(_context.Resolutions, "ResolutionId", "Name", laptop.ResolutionId);
            ViewData["ScreenSizeId"] = new SelectList(_context.ScreenSizes, "ScreenSizeId", "Name", laptop.ScreenSizeId);
            return View(laptop);
        }

        // GET: Laptops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laptop = await _context.Laptops
                .Include(l => l.Brand)
                .Include(l => l.CPU)
                .Include(l => l.GPU)
                .Include(l => l.RAM)
                .Include(l => l.Resolution)
                .Include(l => l.ScreenSize)
                .FirstOrDefaultAsync(m => m.LaptopId == id);
            if (laptop == null)
            {
                return NotFound();
            }

            return View(laptop);
        }

        // POST: Laptops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var laptop = await _context.Laptops.FindAsync(id);

            //TODO delete image from wwwroot
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "image", laptop.ImageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
            //deletethe record


            _context.Laptops.Remove(laptop);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LaptopExists(int id)
        {
            return _context.Laptops.Any(e => e.LaptopId == id);
        }
    }
}
