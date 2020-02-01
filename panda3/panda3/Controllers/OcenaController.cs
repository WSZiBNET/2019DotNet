using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using panda3.Data;
using panda3.Models;

namespace panda3.Controllers
{
    public class OcenaController : Controller
    {
        private readonly KomputerDbContext _context;

        public OcenaController(KomputerDbContext context)
        {
            _context = context;
        }

        // GET: Ocena
        public async Task<IActionResult> Index()
        {
            return View(await _context.OcenaModel.ToListAsync());
        }

        // GET: Ocena/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ocenaModel = await _context.OcenaModel
                .SingleOrDefaultAsync(m => m.OcenaID == id);
            if (ocenaModel == null)
            {
                return NotFound();
            }

            return View(ocenaModel);
        }

        // GET: Ocena/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ocena/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OcenaID,KomputerID,Ocena")] OcenaModel ocenaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ocenaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ocenaModel);
        }

        // GET: Ocena/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ocenaModel = await _context.OcenaModel.SingleOrDefaultAsync(m => m.OcenaID == id);
            if (ocenaModel == null)
            {
                return NotFound();
            }
            return View(ocenaModel);
        }

        // POST: Ocena/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OcenaID,KomputerID,Ocena")] OcenaModel ocenaModel)
        {
            if (id != ocenaModel.OcenaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ocenaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OcenaModelExists(ocenaModel.OcenaID))
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
            return View(ocenaModel);
        }

        // GET: Ocena/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ocenaModel = await _context.OcenaModel
                .SingleOrDefaultAsync(m => m.OcenaID == id);
            if (ocenaModel == null)
            {
                return NotFound();
            }

            return View(ocenaModel);
        }

        // POST: Ocena/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ocenaModel = await _context.OcenaModel.SingleOrDefaultAsync(m => m.OcenaID == id);
            _context.OcenaModel.Remove(ocenaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OcenaModelExists(int id)
        {
            return _context.OcenaModel.Any(e => e.OcenaID == id);
        }
    }
}
