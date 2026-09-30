using MovieManager.Repository;

namespace MovieManager.Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new MovieDBContext();
            var actors = db.Actors.ToArray();
            
        }
    }
}
