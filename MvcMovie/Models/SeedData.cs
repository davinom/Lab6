using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any() && context.Reviews.Any())
                {
                    return;   // DB has been seeded
                }
                
                context.Reviews.AddRange(
                    new Reviews
                    {
                        //ReviewId = 1,
                        Author = "Matt",
                        Review = "good",
                        MovieID= 4
                        //Title = "When Harry Met Sally"
                    },

                    new Reviews
                    {
                        //ReviewId = 1,
                        Author = "Matt",
                        Review = "pretty good",
                        MovieID = 4
                        //Title = "When Harry Met Sally"
                    },


                new Reviews
                {
                        //ReviewId = 1,
                        Author = "Ghost",
                        Review = "Welp, I got Busted",
                        MovieID = 5
                        //Title = "When Harry Met Sally"
                    },


                    new Reviews
                    {
                        //ReviewId = 1,
                        Author = "Ghost Two",
                        Review = "I got busted yet again",
                        MovieID = 6
                        //Title = "When Harry Met Sally"
                    },

                     new Reviews
                      {
                        //ReviewId = 1,
                        Author = "Rio",
                        Review = "Bravo",
                         MovieID = 7
                        //Title = "When Harry Met Sally"
                    }

                        );


                context.Movie.AddRange(
                     new Movie
                     {
                         Title = "When Harry Met Sally",
                         ReleaseDate = DateTime.Parse("1989-1-11"),
                         Genre = "Romantic Comedy",
                         Rating= "R",
                         Price = 7.99M
                     },

                     new Movie
                     {
                         Title = "Ghostbusters ",
                         ReleaseDate = DateTime.Parse("1984-3-13"),
                         Genre = "Comedy",
                         Rating = "PG-13",
                         Price = 8.99M
                     },

                     new Movie
                     {
                         Title = "Ghostbusters 2",
                         ReleaseDate = DateTime.Parse("1986-2-23"),
                         Genre = "Comedy",
                         Rating = "PG-13",
                         Price = 9.99M
                     },

                   new Movie
                   {
                       Title = "Rio Bravo",
                       ReleaseDate = DateTime.Parse("1959-4-15"),
                       Genre = "Western",
                       Rating = "NR",
                       Price = 3.99M
                   }
                );
                context.SaveChanges();
            }
        }
    }
}