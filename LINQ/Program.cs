using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Movie> movies = new List<Movie> {
            new Movie("Blood Diamond", "Leonardo DiCaprio", 8, 2006),
            new Movie("The Departed", "Leonardo DiCaprio", 8.5, 2006),
            new Movie("Gladiator", "Russell Crowe", 8.5, 2000),
            new Movie("A Beautiful Mind", "Russell Crowe", 8.2, 2001),
            new Movie("Good Will Hunting", "Matt Damon", 8.3, 1997),
            new Movie("The Martian", "Matt Damon", 8, 2015),
        };

            List<Actor> actors = new List<Actor> {
                new Actor { FullName = "Matt Damon", Age = 48 },
                new Actor { FullName = "Leonardo DiCaprio", Age = 44 },
            };

            // .First crashes app with an exception if the item isn't found.
            // Movie selectedMovie = movies.First(movie => movie.Title == "Die Hard");
            Movie selectedMovie = movies.FirstOrDefault(movie => movie.Title == "Die Hard");
            // Console.WriteLine("selectedMovie: " + selectedMovie);

            int oldestYear = movies.Min(m => m.Year);
            // Console.WriteLine("oldest year: " + oldestYear);

            selectedMovie = movies.FirstOrDefault(m => m.Year == oldestYear);
            // selectedMovie = movies.FirstOrDefault(m => m.Year == movies.Min(mov => mov.Year));
            // Console.WriteLine("selectedMovie: " + selectedMovie);

            IEnumerable<Movie> filteredMovies = movies
                .Where(m => m.LeadActor == "Leonardo DiCaprio")
                .OrderByDescending(m => m.Rating);
            // .ToList();

            filteredMovies = movies.Where(m => m.Title.StartsWith("T"));
            PrintEach(filteredMovies);

            IEnumerable<string> newerRussellMovieTitles = movies
                .Where(m => m.LeadActor == "Russell Crowe" && m.Year > 2000)
                .Select(m => m.Title);

            PrintEach(newerRussellMovieTitles);

            // Extra, not needed for exam.
            var moviesAndActor = movies
                .Join(actors, // join with actors list
                    movie => movie.LeadActor, // movie.LeadActor ==
                    actor => actor.FullName, // actor.FullName
                    (movie, actor) => new { movie, actor } // return new dict with movie and actor inside
                ).Where(movieAndActor => movieAndActor.actor.FullName == "Leonardo DiCaprio")
                .ToList();

            PrintEach(moviesAndActor);
            Console.WriteLine(moviesAndActor[0].actor.Age);
        }

        public static void PrintEach(IEnumerable<dynamic> items, string msg = "")
        {
            Console.WriteLine("\n" + msg);

            foreach (var item in items)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
