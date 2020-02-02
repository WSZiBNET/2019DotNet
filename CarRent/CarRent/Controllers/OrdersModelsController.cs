using System;
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
    public class OrdersModelsController : Controller
    {
        private readonly CarDataContext _context;

        public OrdersModelsController(CarDataContext context)
        {
            _context = context;
        }

        // GET: OrdersModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrdersModel.ToListAsync());
        }

        // GET: OrdersModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordersModel = await _context.OrdersModel
                .FirstOrDefaultAsync(m => m.IdOrder == id);
            if (ordersModel == null)
            {
                return NotFound();
            }

            return View(ordersModel);
        }

        // GET: OrdersModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrdersModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOrder,IdClient,IdCar,Price,OrderDateFrom,ReturnDate,PayDate,Score")] OrdersModel ordersModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordersModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ordersModel);
        }

        // GET: OrdersModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordersModel = await _context.OrdersModel.FindAsync(id);
            if (ordersModel == null)
            {
                return NotFound();
            }
            return View(ordersModel);
        }

        // POST: OrdersModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOrder,IdClient,IdCar,Price,OrderDateFrom,ReturnDate,PayDate,Score")] OrdersModel ordersModel)
        {
            if (id != ordersModel.IdOrder)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordersModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersModelExists(ordersModel.IdOrder))
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
            return View(ordersModel);
        }

        // GET: OrdersModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordersModel = await _context.OrdersModel
                .FirstOrDefaultAsync(m => m.IdOrder == id);
            if (ordersModel == null)
            {
                return NotFound();
            }

            return View(ordersModel);
        }

        // POST: OrdersModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ordersModel = await _context.OrdersModel.FindAsync(id);
            _context.OrdersModel.Remove(ordersModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdersModelExists(int id)
        {
            return _context.OrdersModel.Any(e => e.IdOrder == id);
        }
    }
}
