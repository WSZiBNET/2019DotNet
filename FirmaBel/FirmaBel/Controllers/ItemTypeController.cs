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
    public class ItemTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ItemType
        public async Task<IActionResult> Index()
        {
            return View(await _context.ItemTypes.ToListAsync());
        }

        // GET: ItemType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemTypeModel = await _context.ItemTypes
                .SingleOrDefaultAsync(m => m.ID == id);
            if (itemTypeModel == null)
            {
                return NotFound();
            }

            return View(itemTypeModel);
        }

        // GET: ItemType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ItemType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TypeName")] ItemTypeModel itemTypeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemTypeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(itemTypeModel);
        }

        // GET: ItemType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemTypeModel = await _context.ItemTypes.SingleOrDefaultAsync(m => m.ID == id);
            if (itemTypeModel == null)
            {
                return NotFound();
            }
            return View(itemTypeModel);
        }

        // POST: ItemType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TypeName")] ItemTypeModel itemTypeModel)
        {
            if (id != itemTypeModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemTypeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemTypeModelExists(itemTypeModel.ID))
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
            return View(itemTypeModel);
        }

        // GET: ItemType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemTypeModel = await _context.ItemTypes
                .SingleOrDefaultAsync(m => m.ID == id);
            if (itemTypeModel == null)
            {
                return NotFound();
            }

            return View(itemTypeModel);
        }

        // POST: ItemType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemTypeModel = await _context.ItemTypes.SingleOrDefaultAsync(m => m.ID == id);
            _context.ItemTypes.Remove(itemTypeModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemTypeModelExists(int id)
        {
            return _context.ItemTypes.Any(e => e.ID == id);
        }
    }
}
