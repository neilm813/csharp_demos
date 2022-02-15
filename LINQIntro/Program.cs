using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Movie> movies = new List<Movie> {
                new Movie("Blood Diamond", "Leonardo DiCaprio", 8, 2006),
                new Movie("The Martian", "Matt Damon", 8, 2015),
                new Movie("The Departed", "Leonardo DiCaprio", 8.5, 2006),
                new Movie("Gladiator", "Russell Crowe", 8.5, 2000),
                new Movie("A Beautiful Mind", "Russell Crowe", 8.2, 2001),
                new Movie("Good Will Hunting", "Matt Damon", 8.3, 1997),
            };

            List<Actor> actors = new List<Actor> {
                new Actor { FullName = "Matt Damon", Age = 48 },
                new Actor { FullName = "Leonardo DiCaprio", Age = 44 },
            };

            // Crashes app when not found, so we use FirstOrDefault instead.
            // Movie selectedMovie = movies.First(m => m.Title == "abc");

            /* 
            The fat arrow: => indicates a lambda expression, you can think of
            as a callback function.

            FirstOrDefault takes a 'lambda predicate' which needs to always
            return a boolean, true if it is the element we want to be selected,
            otherwise false.

                                        .FirstOrDefault(paramName => paramName.property == "some-value");
            */
            Movie selectedMovie = movies.FirstOrDefault(m => m.Title == "abc");

            List<Movie> filteredMovies = movies
                .Where(m => m.LeadActor == "Leonardo DiCaprio")
                .ToList();

            // PrintEach(filteredMovies, "Leo's Movies");

            // Console.WriteLine(selectedMovie);
            filteredMovies = movies
            .Where(m => m.Year > 2000 && m.LeadActor == "Russell Crowe")
            .ToList();

            // PrintEach(filteredMovies, "Russell movies after year 2000");

            List<string> filteredMovieTitles = movies
                .Where(m => m.Title.ToLower().Contains("the"))
                // .Select takes a lambda selector, not a predicate.
                // .Select(paramName => paramName.columnToSelect)
                .Select(m => m.Title)
                /* 
                Since we just selected the titles, now OrderBy only has access
                to the title. This is alphabetical.
                */
                .OrderBy(title => title)
                .ToList();

            PrintEach(filteredMovieTitles, "Movie titles containing 'the'.");

            List<string> filteredMovieTitlesOrderedByRating = movies
                .Where(m => m.Title.ToLower().Contains("the"))
                // Order by before we select so we have access to the Rating.
                .OrderByDescending(m => m.Rating)
                // .Select takes a lambda selector, not a predicate.
                // .Select(paramName => paramName.columnToSelect)
                .Select(m => m.Title)
                .ToList();

            PrintEach(filteredMovieTitlesOrderedByRating, "Movie titles containing 'the' ordered by highest.");

            var moviesAndActor = movies
                .Join(actors, // join with actors list
                    movie => movie.LeadActor, // movie.LeadActor == actor.FullName
                    actor => actor.FullName, // actor.FullName
                    (movie, actor) => new { movie, actor } // return new dict with movie and actor inside
                ).Where(movieAndActor => movieAndActor.actor.FullName == "Leonardo DiCaprio")
                .ToList();

            PrintEach(moviesAndActor);
            Console.WriteLine(moviesAndActor[0].actor.Age);

            Movie oldestMovie = movies
                .FirstOrDefault(m => m.Year == movies.Min(m => m.Year));

            Console.WriteLine(oldestMovie);

        }

        public static void PrintEach(IEnumerable<dynamic> items, string label = "")
        {
            Console.WriteLine("\n" + label);

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
