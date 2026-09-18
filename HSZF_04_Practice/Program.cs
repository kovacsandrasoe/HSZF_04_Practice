using HSZF_04_Practice.Contexts;
using HSZF_04_Practice.Entities;
using Microsoft.EntityFrameworkCore;

namespace HSZF_04_Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Movie DB handler app");

            var context = new MovieDBContext();
            //BasicDataListingWithLazyLoadingTest(context);

            //FilmsWithDirectorData(context);

            RolesByActors(context);

            Console.ReadLine();
        }

        private static void RolesByActors(MovieDBContext context)
        {
            // Query #2
            Console.WriteLine("--- Query #2: Actors with their roles in movies up to role priority 5 --- ");
            var actorsWithRoles = (from actor in context.Actors
                                   join role in context.Roles
                                     on actor.Id equals role.ActorId
                                   join movie in context.Movies
                                     on role.MovieId equals movie.Id
                                   where role.Priority <= 5
                                   orderby actor.Name
                                   select new
                                   {
                                       actorId = actor.Id,
                                       movieId = movie.Id,
                                       actorName = actor.Name,
                                       movieTitle = movie.Title,
                                       roleName = role.Name,
                                       rolePriority = role.Priority,
                                   }).ToList();

            foreach (var actor in actorsWithRoles)
            {
                Console.WriteLine("{0} | {1} | {2} | {3}", actor.actorName, actor.movieTitle, actor.roleName, actor.rolePriority);
            }

            Console.WriteLine("\nWith navprops and eager load:");

            var actorsWithRoles2 = (from role in context.Roles.Include(x => x.Actor).Include(x => x.Movie)
                                    where role.Priority <= 5
                                    orderby role.Actor.Name
                                    select new
                                    {
                                        actorId = role.Actor.Id,
                                        movieId = role.Movie.Id,
                                        actorName = role.Actor.Name,
                                        movieTitle = role.Movie.Title,
                                        roleName = role.Name,
                                        rolePriority = role.Priority,
                                    }).ToList();

            foreach (var actor in actorsWithRoles2)
            {
                Console.WriteLine("{0} | {1} | {2} | {3}", actor.actorName, actor.movieTitle, actor.roleName, actor.rolePriority);
            }
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
