using HSZF_04_Practice.Contexts;

namespace HSZF_04_Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var context = new MovieDBContext();

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

            Console.ReadLine();
        }
    }
}
