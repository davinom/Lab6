﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly MvcMovieContext _context;

        public ReviewsController(MvcMovieContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(List<Reviews> movieReviews, bool? sorting)
        {
            IQueryable<int> movieReviewQuery = from m in _context.Movie
                                               orderby m.ID
                                               select m.ID;

            var reviews = from m in _context.Reviews
                          select m;

            var movieReviewVM = new MovieReview();
            //movieReviewVM.movie = movie;
            movieReviewVM.mReview = new SelectList(await movieReviewQuery.Distinct().ToListAsync());
            movieReviewVM.review = await reviews.ToListAsync();

            //ViewData["mID"] = movieReviewVM.movie.ID;
            if(sorting==false || sorting==null)
            {
        
            }
            else if (sorting==true)
            {

            }
            return View(movieReviewVM);
        }
        // GET: Reviews/Create
        public IActionResult Create(int? id)
        {
            var movies = from m in _context.Movie
                         select m;

            foreach (var item in movies)
            {
                if (item.ID == id)
                {
                    ViewData["mTitle"] = item.Title;
                    ViewData["mID"] = id;
                }
            }
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Author,Review,MovieID")] Reviews review, int? id)
        {
            if (ModelState.IsValid)
            {
                review.MovieID = (int)id;
                _context.Add(review);

                ViewData["mID"] = review.MovieID;
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Movies", new { id = review.MovieID });
            }
            return View(review);
        }

        // GET: Reviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews.SingleOrDefaultAsync(m => m.ID == id);
            if (review == null)
            {
                return NotFound();
            }
            ViewData["mID"] = review.MovieID;

            var movies = from m in _context.Movie
                         select m;

            foreach (var item in movies)
            {
                if (item.ID == review.MovieID)
                {
                    Console.WriteLine("EDIT ITEM ID: " + item.ID);
                    Console.WriteLine("EDIT MOVIE ID: " + review.MovieID);
                    Console.WriteLine("EDIT TITLE: " + item.Title);
                    ViewData["mTitle"] = item.Title;
                }
            }

            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,MovieReview,MovieID")] Reviews review)
        {
            if (id != review.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(review);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewExists(review.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Movies", new { id = review.MovieID });
            }
            return View(review);
        }

        // GET: Reviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews
                .SingleOrDefaultAsync(m => m.ID == id);

            if (review == null)
            {
                return NotFound();
            }
            else
            {
                var movies = from m in _context.Movie
                             select m;

                foreach (var item in movies)
                {
                    if (item.ID == review.MovieID)
                    {
                        ViewData["mTitle"] = item.Title;
                        ViewData["mID"] = item.ID;
                    }
                }
            }

            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var review = await _context.Reviews.SingleOrDefaultAsync(m => m.ID == id);
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Movies", new { id = review.MovieID });
        }

        private bool ReviewExists(int id)
        {
            return _context.Reviews.Any(e => e.ID == id);
        }
    }
}

