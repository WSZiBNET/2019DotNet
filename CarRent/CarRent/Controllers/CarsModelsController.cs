﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRent.Data;
using CarRent.Models;

namespace CarRent.Controllers
{
    public class CarsModelsController : Controller
    {
        private readonly CarDataContext _context;

        public CarsModelsController(CarDataContext context)
        {
            _context = context;
        }

        // GET: CarsModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cars.ToListAsync());
        }

        // GET: CarsModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carsModel = await _context.Cars
                .FirstOrDefaultAsync(m => m.IdCar == id);
            if (carsModel == null)
            {
                return NotFound();
            }

            return View(carsModel);
        }

        // GET: CarsModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarsModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCar,Brand,Type,ProductionYear,Package,Combustion,ReservationStatus")] CarsModel carsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carsModel);
        }

        // GET: CarsModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carsModel = await _context.Cars.FindAsync(id);
            if (carsModel == null)
            {
                return NotFound();
            }
            return View(carsModel);
        }

        // POST: CarsModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCar,Brand,Type,ProductionYear,Package,Combustion,ReservationStatus")] CarsModel carsModel)
        {
            if (id != carsModel.IdCar)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarsModelExists(carsModel.IdCar))
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
            return View(carsModel);
        }

        // GET: CarsModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carsModel = await _context.Cars
                .FirstOrDefaultAsync(m => m.IdCar == id);
            if (carsModel == null)
            {
                return NotFound();
            }

            return View(carsModel);
        }

        // POST: CarsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carsModel = await _context.Cars.FindAsync(id);
            _context.Cars.Remove(carsModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarsModelExists(int id)
        {
            return _context.Cars.Any(e => e.IdCar == id);
        }
    }
}
