﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WatchList.Web.Data;
using WatchList.Web.Models;

namespace WatchList.Web.Controllers
{
    public class TvShowsController : Controller
    {
        private readonly WatchListDataContext _context;

        public TvShowsController(WatchListDataContext context)
        {
            _context = context;
        }

        // GET: TvShows
        public async Task<IActionResult> Index()
        {
            var watchListDataContext = _context.TvShow.Include(t => t.Rating);
            return View(await watchListDataContext.ToListAsync());
        }

        // GET: TvShows/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvShow = await _context.TvShow
                .Include(t => t.Rating)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tvShow == null)
            {
                return NotFound();
            }

            return View(tvShow);
        }

        // GET: TvShows/Create
        public IActionResult Create()
        {
            ViewData["RatingId"] = new SelectList(_context.Set<Rating>(), "Id", "Name");
            return View();
        }

        // POST: TvShows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,WatchDate,RatingId")] TvShow tvShow)
        {
            if (ModelState.IsValid)
            {
                tvShow.Id = Guid.NewGuid();
                _context.Add(tvShow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RatingId"] = new SelectList(_context.Set<Rating>(), "Id", "Name", tvShow.RatingId);
            return View(tvShow);
        }

        // GET: TvShows/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvShow = await _context.TvShow.FindAsync(id);
            if (tvShow == null)
            {
                return NotFound();
            }
            ViewData["RatingId"] = new SelectList(_context.Set<Rating>(), "Id", "Name", tvShow.RatingId);
            return View(tvShow);
        }

        // POST: TvShows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,WatchDate,RatingId")] TvShow tvShow)
        {
            if (id != tvShow.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tvShow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TvShowExists(tvShow.Id))
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
            ViewData["RatingId"] = new SelectList(_context.Set<Rating>(), "Id", "Name", tvShow.RatingId);
            return View(tvShow);
        }

        // GET: TvShows/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvShow = await _context.TvShow
                .Include(t => t.Rating)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tvShow == null)
            {
                return NotFound();
            }

            return View(tvShow);
        }

        // POST: TvShows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tvShow = await _context.TvShow.FindAsync(id);
            if (tvShow != null)
            {
                _context.TvShow.Remove(tvShow);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TvShowExists(Guid id)
        {
            return _context.TvShow.Any(e => e.Id == id);
        }
    }
}
