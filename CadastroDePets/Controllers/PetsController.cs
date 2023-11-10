using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CadastroDePets.Models;

namespace CadastroDePets.Controllers
{
    public class PetsController : Controller
    {
        private readonly Context _context;

        public PetsController(Context context)
        {
            _context = context;
        }

        // GET: Pets
        public async Task<IActionResult> Index()
        {
              return _context.Pets != null ? 
                          View(await _context.Pets.ToListAsync()) :
                          Problem("Entity set 'Context.Pets'  is null.");
        }

        // GET: Pets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pets == null)
            {
                return NotFound();
            }

            var pets = await _context.Pets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pets == null)
            {
                return NotFound();
            }

            return View(pets);
        }

        // GET: Pets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomePet,NomeDono,Telefone")] Pets pets)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pets);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pets);
        }

        // GET: Pets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pets == null)
            {
                return NotFound();
            }

            var pets = await _context.Pets.FindAsync(id);
            if (pets == null)
            {
                return NotFound();
            }
            return View(pets);
        }

        // POST: Pets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomePet,NomeDono,Telefone")] Pets pets)
        {
            if (id != pets.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pets);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetsExists(pets.Id))
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
            return View(pets);
        }

        // GET: Pets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pets == null)
            {
                return NotFound();
            }

            var pets = await _context.Pets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pets == null)
            {
                return NotFound();
            }

            return View(pets);
        }

        // POST: Pets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pets == null)
            {
                return Problem("Entity set 'Context.Pets'  is null.");
            }
            var pets = await _context.Pets.FindAsync(id);
            if (pets != null)
            {
                _context.Pets.Remove(pets);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PetsExists(int id)
        {
          return (_context.Pets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
