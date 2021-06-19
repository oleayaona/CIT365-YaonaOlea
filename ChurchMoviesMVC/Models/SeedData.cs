using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;


namespace ChurchMoviesMVC.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "The RM",
                        ReleaseDate = DateTime.Parse("2003-9-12"),
                        Genre = "Comedy",
                        Rating = "PG",
                        Price = 4.99M,
                        ImageURL = "https://d1hdlz9ljonw49.cloudfront.net/product-images/000/315/559/detail/thrmdvd.jpg"
                    },

                    new Movie
                    {
                        Title = "The Singles Ward",
                        ReleaseDate = DateTime.Parse("2005-3-13"),
                        Genre = "Romantic Comedy",
                        Rating = "PG",
                        Price = 4.99M,
                        ImageURL = "https://d1hdlz9ljonw49.cloudfront.net/product-images/000/738/520/detail/TheSinglesWard.jpeg?1586287870"
                    },

                    new Movie
                    {
                        Title = "Lamb of God",
                        ReleaseDate = DateTime.Parse("2021-2-23"),
                        Genre = "Concert Film",
                        Rating = "PG",
                        Price = 19.99M,
                        ImageURL = "https://d2ncbdssutn1hp.cloudfront.net/product-images/000/741/516/detail/Lamb-of-God-DVD-Cover.png?1617652709"
                    },

                    new Movie
                    {
                        Title = "In Times of Rain and War",
                        ReleaseDate = DateTime.Parse("2021-4-15"),
                        Genre = "Drama",
                        Rating = "PG",
                        Price = 22.94M,
                        ImageURL = "https://d26iejr7yj7kfh.cloudfront.net/product-images/000/740/658/detail/In_Times_of_Rain_and_War.jpg?1610398215"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
