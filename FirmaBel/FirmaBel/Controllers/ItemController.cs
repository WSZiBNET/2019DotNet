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
    public class ItemController : Controller
    {
        private readonly DataDbContext _context;

        public ItemController(DataDbContext context)
        {
            _context = context;
        }

        // GET: Item
        public async Task<IActionResult> Index()
        {
         


            var item = await _context.Items.ToListAsync();
            var ittype = await _context.ItemTypes.ToListAsync();
            var itcat = await _context.ItemCategories.ToListAsync();
            var model = new ItemViewModel { Items = item, ItemType = ittype, ItemCategory = itcat };
            return View(model);


        }

        // GET: Item/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemModel = await _context.Items
                .Include(i => i.ItemCategory)
                .Include(i => i.ItemType)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (itemModel == null)
            {
                return NotFound();
            }

            return View(itemModel);
        }

        // GET: Item/Create
        public IActionResult Create()
        {
            ViewData["Category"] = new SelectList(_context.ItemCategories, "ID", "CategoryName");
            ViewData["TypeName"] = new SelectList(_context.ItemTypes, "ID", "TypeName");
            return View();
        }

        // POST: Item/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TypeName,Name,Price,Category")] ItemModel itemModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Category"] = new SelectList(_context.ItemCategories, "ID", "ID", itemModel.Category);
            ViewData["TypeName"] = new SelectList(_context.ItemTypes, "ID", "ID", itemModel.TypeName);
            return View(itemModel);
        }

        // GET: Item/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemModel = await _context.Items.SingleOrDefaultAsync(m => m.ID == id);
            if (itemModel == null)
            {
                return NotFound();
            }
            ViewData["Category"] = new SelectList(_context.ItemCategories, "ID", "ID", itemModel.Category);
            ViewData["TypeName"] = new SelectList(_context.ItemTypes, "ID", "ID", itemModel.TypeName);
            return View(itemModel);
        }

        // POST: Item/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TypeName,Name,Price,Category")] ItemModel itemModel)
        {
            if (id != itemModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemModelExists(itemModel.ID))
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
            ViewData["Category"] = new SelectList(_context.ItemCategories, "ID", "ID", itemModel.Category);
            ViewData["TypeName"] = new SelectList(_context.ItemTypes, "ID", "ID", itemModel.TypeName);
            return View(itemModel);
        }

        // GET: Item/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemModel = await _context.Items
                .Include(i => i.ItemCategory)
                .Include(i => i.ItemType)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (itemModel == null)
            {
                return NotFound();
            }

            return View(itemModel);
        }

        // POST: Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemModel = await _context.Items.SingleOrDefaultAsync(m => m.ID == id);
            _context.Items.Remove(itemModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemModelExists(int id)
        {
            return _context.Items.Any(e => e.ID == id);
        }
    }
}
