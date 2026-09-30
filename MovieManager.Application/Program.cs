using MovieManager.Repository;

namespace MovieManager.Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new MovieDBContext();
            var repo = new MovieRepository(db);

            var movies = repo.ReadAll();
            ;
            
        }
    }
}
