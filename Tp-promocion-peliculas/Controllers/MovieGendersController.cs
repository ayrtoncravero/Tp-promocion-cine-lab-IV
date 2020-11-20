using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tp_promocion_peliculas;
using Tp_promocion_peliculas.Models;

namespace Tp_promocion_peliculas.Controllers
{
    public class MovieGendersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovieGendersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MovieGenders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MovieGenders.Include(m => m.Film).Include(m => m.Gender);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MovieGenders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieGender = await _context.MovieGenders
                .Include(m => m.Film)
                .Include(m => m.Gender)
                .FirstOrDefaultAsync(m => m.FilmId == id);
            if (movieGender == null)
            {
                return NotFound();
            }

            return View(movieGender);
        }

        // GET: MovieGenders/Create
        public IActionResult Create()
        {
            ViewData["FilmId"] = new SelectList(_context.Movies, "Id", "Title");
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Description");
            return View();
        }

        // POST: MovieGenders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FilmId,GenderId")] MovieGender movieGender)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieGender);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FilmId"] = new SelectList(_context.Movies, "Id", "Summary", movieGender.FilmId);
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Description", movieGender.GenderId);
            return View(movieGender);
        }

        // GET: MovieGenders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieGender = await _context.MovieGenders.FindAsync(id);
            if (movieGender == null)
            {
                return NotFound();
            }
            ViewData["FilmId"] = new SelectList(_context.Movies, "Id", "Summary", movieGender.FilmId);
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Description", movieGender.GenderId);
            return View(movieGender);
        }

        // POST: MovieGenders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FilmId,GenderId")] MovieGender movieGender)
        {
            if (id != movieGender.FilmId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieGender);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieGenderExists(movieGender.FilmId))
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
            ViewData["FilmId"] = new SelectList(_context.Movies, "Id", "Summary", movieGender.FilmId);
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Description", movieGender.GenderId);
            return View(movieGender);
        }

        // GET: MovieGenders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieGender = await _context.MovieGenders
                .Include(m => m.Film)
                .Include(m => m.Gender)
                .FirstOrDefaultAsync(m => m.FilmId == id);
            if (movieGender == null)
            {
                return NotFound();
            }

            return View(movieGender);
        }

        // POST: MovieGenders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieGender = await _context.MovieGenders.FindAsync(id);
            _context.MovieGenders.Remove(movieGender);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieGenderExists(int id)
        {
            return _context.MovieGenders.Any(e => e.FilmId == id);
        }
    }
}
