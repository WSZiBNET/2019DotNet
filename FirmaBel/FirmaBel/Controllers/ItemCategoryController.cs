using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FirmaBel.Data;
using FirmaBel.Models;

namespace FirmaBel.Controllers
{
    public class ItemCategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemCategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ItemCategory
        public async Task<IActionResult> Index()
        {
            return View(await _context.ItemCategories.ToListAsync());
        }

        // GET: ItemCategory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemCategoryModel = await _context.ItemCategories
                .SingleOrDefaultAsync(m => m.ID == id);
            if (itemCategoryModel == null)
            {
                return NotFound();
            }

            return View(itemCategoryModel);
        }

        // GET: ItemCategory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ItemCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CategoryName")] ItemCategoryModel itemCategoryModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemCategoryModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(itemCategoryModel);
        }

        // GET: ItemCategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemCategoryModel = await _context.ItemCategories.SingleOrDefaultAsync(m => m.ID == id);
            if (itemCategoryModel == null)
            {
                return NotFound();
            }
            return View(itemCategoryModel);
        }

        // POST: ItemCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CategoryName")] ItemCategoryModel itemCategoryModel)
        {
            if (id != itemCategoryModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemCategoryModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemCategoryModelExists(itemCategoryModel.ID))
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
            return View(itemCategoryModel);
        }

        // GET: ItemCategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemCategoryModel = await _context.ItemCategories
                .SingleOrDefaultAsync(m => m.ID == id);
            if (itemCategoryModel == null)
            {
                return NotFound();
            }

            return View(itemCategoryModel);
        }

        // POST: ItemCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemCategoryModel = await _context.ItemCategories.SingleOrDefaultAsync(m => m.ID == id);
            _context.ItemCategories.Remove(itemCategoryModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemCategoryModelExists(int id)
        {
            return _context.ItemCategories.Any(e => e.ID == id);
        }
    }
}
