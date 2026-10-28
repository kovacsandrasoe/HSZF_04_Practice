namespace MovieManager.ConsoleClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Client c = new Client("https://localhost:7122", new HttpClient());

            var movies = c.MovieAll();
            ;
        }
    }
}
