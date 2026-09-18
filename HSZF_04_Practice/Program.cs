using HSZF_04_Practice.Contexts;

namespace HSZF_04_Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Movie DB handler app");

            var context = new MovieDBContext();
            //BasicDataListingWithLazyLoadingTest(context);

            FilmsWithDirectorData(context);

            Console.ReadLine();
        }

        private static void FilmsWithDirectorData(MovieDBContext context)
        {
            // Query #1.
            Console.WriteLine("--- Query #1: Films with director data --- ");
            var movieDetails = from movie in context.Movies
                               join director in context.Directors
                                    on movie.DirectorId equals director.Id
                               select new
                               {
                                   Title = movie.Title,
                                   movie.Release, // Not necessary the name definition
                                   DirectorName = director.Name,
                                   movie.Income,
                                   movie.Rating,
                               };

            var orderedMovieDetails = movieDetails.OrderBy(x => x.Release).ThenByDescending(x => x.Rating).ToList();

            foreach (var movie in orderedMovieDetails)
            {
                Console.WriteLine("[{0}] {1} (Director: {2}) - Rating: {3}; Income: {4}", movie.Release.Year, movie.Title, movie.DirectorName, movie.Rating, movie.Income);
            }
        }

        private static void BasicDataListingWithLazyLoadingTest(MovieDBContext context)
        {
            Console.WriteLine("Directors: ");

            foreach (var director in context.Directors)
            {
                Console.WriteLine($"{director.Name} and his/her movies: {String.Join(", ", director.Movies.Select(x => x.Title))}");
            }

            Console.WriteLine("\n\nActors:");

            foreach (var actor in context.Actors)
            {
                Console.WriteLine($"{actor.Name} and his/her roles: {String.Join(", ", actor.Roles.Select(x => x.Name))}");
            }

            Console.WriteLine("\n\nMovies:");

            foreach (var movie in context.Movies)
            {
                Console.WriteLine(movie.Title);
            }

            Console.WriteLine("\n\nRoles:");

            foreach (var role in context.Roles)
            {
                Console.WriteLine($"{role.Name} on film '{role.Movie.Title}' for actor '{role.Actor.Name}'");
            }
        }
    }
}
