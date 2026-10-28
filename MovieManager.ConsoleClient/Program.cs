namespace MovieManager.ConsoleClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Client c = new Client("https://localhost:7122", new HttpClient());

            var newMovie = new MovieCreateUpdateDto()
            {
                Title = "Secret War",
                Income = 1000,
                Rating = 4,
                DirectorId = 5,
                Release = DateTime.Now
            };
            c.MoviePOST(newMovie);
            var movies = c.MovieAll();
            
        }
    }
}
