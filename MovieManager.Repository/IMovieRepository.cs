using MovieManager.Models.Entities;

namespace MovieManager.Repository
{
    public interface IMovieRepository
    {
        void Create(Movie movie);
        void Delete(int id);
        Movie Read(int id);
        IQueryable<Movie> ReadAll();
        void Update(Movie movie);
    }
}