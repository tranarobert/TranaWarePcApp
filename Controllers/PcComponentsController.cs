using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TranaWarePc.Models;
using TranaWarePc.Services;
using TranaWarePc.Repositories;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;

namespace TranaWarePc.Controllers
{
    [AllowAnonymous]
    public class PcComponentsController : Controller
    {
        private readonly IPcComponentService _pcComponentService;

        public PcComponentsController(IPcComponentService pcComponentService)
        {
            _pcComponentService = pcComponentService;
        }

        // GET: PcComponents
        public async Task<IActionResult> Index()
        {
            var components = await _pcComponentService.GetAllComponentsAsync();
            return View(components);
        }

        // GET: PcComponents/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var pcComponent = await _pcComponentService.GetComponentByIdAsync(id.Value);
               /* .Include(e => e.CPU)
                .Include(e => e.CPUCooler)
                .Include(e => e.GPU)
                .Include(e => e.HDD)
                .Include(e => e.Motherboard)
                .Include(e => e.PCCase)
                .Include(e => e.PSU)
                .Include(e => e.RAM)
                .Include(e => e.SSD)
                .FirstOrDefaultAsync(m => m.Id == id);*/
            if (pcComponent == null)
            {
                return NotFound();
            }

            return View(pcComponent);
        }

        [Authorize(Roles ="Administrator")]
        // GET: PcComponents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PcComponents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Price,StockQuantity")] PcComponent pcComponent)
        {
            if (ModelState.IsValid)
            {
                await _pcComponentService.CreateComponentAsync(pcComponent);
               // await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pcComponent);
        }

        

        // GET: PcComponents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pcComponent = await _pcComponentService.GetComponentByIdAsync(id.Value);
            if (pcComponent == null)
            {
                return NotFound();
            }
            return View(pcComponent);
        }

        // POST: PcComponents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Price,StockQuantity,Name")] PcComponent pcComponent)
        {
            if (id != pcComponent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                /* try
                 {
                     _context.Update(pcComponent);
                     await _context.SaveChangesAsync();
                 }
                 catch (DbUpdateConcurrencyException)
                 {
                     if (!PcComponentExists(pcComponent.Id))
                     {
                         return NotFound();
                     }
                     else
                     {
                         throw;
                     }
                 }*/
                await _pcComponentService.UpdateComponentAsync(pcComponent);
                return RedirectToAction(nameof(Index));
            }
            return View(pcComponent);
        }

        // GET: PcComponents/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var pcComponent = await _context.PCComponents
                .FirstOrDefaultAsync(m => m.Id == id);*/
            var pcComponent = await _pcComponentService.GetComponentByIdAsync(id.Value);
            if (pcComponent == null)
            {
                return NotFound();
            }

            return View(pcComponent);
        }

        // POST: PcComponents/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            /*var pcComponent = await _context.PCComponents.FindAsync(id);
            if (pcComponent != null)
            {
                _context.PCComponents.Remove(pcComponent);
            }

            await _context.SaveChangesAsync();*/
            await _pcComponentService.DeleteComponentAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool PcComponentExists(int id)
        {
            //return _context.PCComponents.Any(e => e.Id == id);
            return false;
        }

        public async Task<IActionResult> Products(int page = 1)
        {
            var pageSize = 9;

            var products = await _pcComponentService.GetAllComponentsAsync();

            var totalProducts = products.Count();

            var paginatedProducts = products
                .Where(s => s.StockQuantity > 0)
                .OrderBy(s => s.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            //.Select(s => new { s.Id, s.Price, s.Name, s.PhotoFileName });

            int totalPages = (int)Math.Ceiling(totalProducts / (double)pageSize);

            var viewModel = new ProductsViewModel
            {
                Products = paginatedProducts,
                TotalProducts = totalProducts,
                CurrentPage = page,
                TotalPages = totalPages
        };

            //ViewBag.Products = query;
            //ViewBag.TotalProducts = totalProducts;
            //ViewBag.CurrentPage = page;

            return View(viewModel);
        }


        /*public async Task<IActionResult> ListProducts(int page = 1)
        {
            int pageSize = 9;

            // Query to count total products with stock quantity greater than 0
            var totalProducts = await _context.PCComponents
                .Where(s => s.StockQuantity > 0)
                .CountAsync();

            // Query to fetch paginated products
            var products = await _context.PCComponents
                .Where(s => s.StockQuantity > 0)
                .OrderBy(s => s.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(s => new { s.Id, s.Name, s.Price, s.PhotoFileName }) // Select the necessary properties
                .ToListAsync();

            // Assign total count to ViewBag
            ViewBag.TotalProducts = totalProducts;
            ViewBag.Products = products;
            ViewBag.CurrentPage = page;

            return View();
        }*/

        public async Task<IActionResult> FilteredProducts(int? id, string searchQuery)
        {

            var filteredProducts = await _pcComponentService.GetAllComponentsAsync();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                searchQuery = searchQuery.ToLower(); 
                filteredProducts = filteredProducts.Where(s => s.Name.ToLower().Contains(searchQuery));
            }

            /*var query = _context.PCComponents
                                .Where(s => s.StockQuantity > 0);

            if (!string.IsNullOrEmpty(searchQuery))
            {
                query = query.Where(s => s.Name.Contains(searchQuery));
            }

            var filteredProducts = await query
                                            .Select(s => new { s.Id, s.Price, s.Name, s.PhotoFileName })
                                            .ToListAsync();

            var totalFilteredCounts = filteredProducts.Count;*/

            ViewBag.searchQuery = searchQuery;
            ViewBag.filteredProducts = filteredProducts;
            ViewBag.HasFilteredProducts = filteredProducts.Any();
            ViewBag.totalFilteredCounts = filteredProducts.Count();

            return View("ProductsSearch");
        }


    }


}
