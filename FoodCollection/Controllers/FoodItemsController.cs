﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoodCollection.Data;
using FoodCollection.Models;

namespace FoodCollection.Controllers
{
    public class FoodItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FoodItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FoodItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.FoodItem.ToListAsync());
        }

        // GET: FoodItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodItem = await _context.FoodItem
                .FirstOrDefaultAsync(m => m.FoodItemId == id);
            if (foodItem == null)
            {
                return NotFound();
            }

            return View(foodItem);
        }

        // GET: FoodItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FoodItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FoodItemId,IsVegetarian,FoodType")] FoodItem foodItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(foodItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(foodItem);
        }

        // GET: FoodItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodItem = await _context.FoodItem.FindAsync(id);
            if (foodItem == null)
            {
                return NotFound();
            }
            return View(foodItem);
        }

        // POST: FoodItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FoodItemId,IsVegetarian,FoodType")] FoodItem foodItem)
        {
            if (id != foodItem.FoodItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foodItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodItemExists(foodItem.FoodItemId))
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
            return View(foodItem);
        }

        // GET: FoodItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodItem = await _context.FoodItem
                .FirstOrDefaultAsync(m => m.FoodItemId == id);
            if (foodItem == null)
            {
                return NotFound();
            }

            return View(foodItem);
        }

        // POST: FoodItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foodItem = await _context.FoodItem.FindAsync(id);
            if (foodItem != null)
            {
                _context.FoodItem.Remove(foodItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodItemExists(int id)
        {
            return _context.FoodItem.Any(e => e.FoodItemId == id);
        }
    }
}
