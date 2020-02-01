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
    public class KomputerModelsController : Controller
    {
        private readonly KomputerDbContext _context;

        public KomputerModelsController(KomputerDbContext context)
        {
            _context = context;
        }

        // GET: KomputerModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Komputer.ToListAsync());
        }

        public async Task<IActionResult> IndexKlient()
        {
            return View(await _context.Komputer.ToListAsync());
        }

        // GET: KomputerModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var komputerModel = await _context.Komputer
                .SingleOrDefaultAsync(m => m.KomputerID == id);
            if (komputerModel == null)
            {
                return NotFound();
            }

            return View(komputerModel);
        }

        // GET: KomputerModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KomputerModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KomputerID,Model,Producent,Cena,DataProdukcji,KartagraficznaID,ProcesorID,PlytaglownaID")] KomputerModel komputerModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(komputerModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(komputerModel);
        }

        // GET: KomputerModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var komputerModel = await _context.Komputer.SingleOrDefaultAsync(m => m.KomputerID == id);
            if (komputerModel == null)
            {
                return NotFound();
            }
            return View(komputerModel);
        }

        // POST: KomputerModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KomputerID,Model,Producent,Cena,DataProdukcji,KartagraficznaID,ProcesorID,PlytaglownaID")] KomputerModel komputerModel)
        {
            if (id != komputerModel.KomputerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(komputerModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KomputerModelExists(komputerModel.KomputerID))
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
            return View(komputerModel);
        }

        // GET: KomputerModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var komputerModel = await _context.Komputer
                .SingleOrDefaultAsync(m => m.KomputerID == id);
            if (komputerModel == null)
            {
                return NotFound();
            }

            return View(komputerModel);
        }

        // POST: KomputerModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var komputerModel = await _context.Komputer.SingleOrDefaultAsync(m => m.KomputerID == id);
            _context.Komputer.Remove(komputerModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KomputerModelExists(int id)
        {
            return _context.Komputer.Any(e => e.KomputerID == id);
        }
    }
}
