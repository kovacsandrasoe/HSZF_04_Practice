using MovieManager.Models;
using MovieManager.Models.Entities;

namespace MovieManager.Logic
{
    public interface IMovieLogic
    {
        void Create(Movie item);
        void Delete(int id);
        double? GetAverageRatePerYear(int year);
        Movie Read(int id);
        IEnumerable<Movie> ReadAll();
        IEnumerable<YearStat> SummaryOfYears();
        void Update(Movie item);
    }
}