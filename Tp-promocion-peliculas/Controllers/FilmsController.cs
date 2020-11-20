using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tp_promocion_peliculas;
using Tp_promocion_peliculas.Models;
using Tp_promocion_peliculas.ViewModel;

namespace Tp_promocion_peliculas.Controllers
{
    public class FilmsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment env;

        public FilmsController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }

        // GET: Films
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Movies.Include(f => f.Genders);
            var viewModel = new MovieViewModel();
            viewModel.Films = await applicationDbContext.ToListAsync();
            return View(viewModel);
        }

        // GET: Films/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Movies
                .Include(f => f.Genders)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // GET: Films/Create
        public IActionResult Create()
        {
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Description");
            return View();
        }

        // POST: Films/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Photo,Trailer,Summary,GenderId,billboard")] Film film)
        {
            if (ModelState.IsValid)
            {
               var file = HttpContext.Request.Form.Files;
                if (file != null && file.Count > 0)
                {
                    var filePhoto = file[0];
                    var pathDestine = Path.Combine(env.WebRootPath, "images\\movies");

                    if (filePhoto.Length > 0)
                    {
                        var fileDestine = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(filePhoto.FileName);

                        using (var filestream = new FileStream(Path.Combine(pathDestine, fileDestine), FileMode.Create))
                        {
                            filePhoto.CopyTo(filestream);
                            film.Photo = fileDestine;
                        };

                    }
                }

                _context.Add(film);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Description", film.GenderId);
            return View(film);
        }

        // GET: Films/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Movies.FindAsync(id);
            if (film == null)
            {
                return NotFound();
            }
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Description", film.GenderId);
            return View(film);
        }

        // POST: Films/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Photo,Trailer,Summary,GenderId,billboard")] Film film)
        {
            if (id != film.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var file = HttpContext.Request.Form.Files;
                if (file != null && file.Count > 0)
                {
                    var filePhoto = file[0];
                    var pathDestine = Path.Combine(env.WebRootPath, "images\\movies");

                    if (filePhoto.Length > 0)
                    {
                        var fileDestine = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(filePhoto.FileName);

                        using (var filestream = new FileStream(Path.Combine(pathDestine, fileDestine), FileMode.Create))
                        {
                            filePhoto.CopyTo(filestream);

                            string oldFile = Path.Combine(pathDestine, film.Photo);
                            if (System.IO.File.Exists(oldFile))
                                System.IO.File.Delete(oldFile);
                            film.Photo = fileDestine;
                        }

                    }
                }

                try
                {
                    _context.Update(film);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmExists(film.Id))
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
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Description", film.GenderId);
            return View(film);
        }

        // GET: Films/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Movies
                .Include(f => f.Genders)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // POST: Films/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var film = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(film);

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (Exception e)
            //{

            //    return this.Problem("No se puede eliminar esta pelicula");
            //}

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool FilmExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
