using MovieManager.Models;
using MovieManager.Models.Dtos.Movie;
using MovieManager.Models.Entities;

namespace MovieManager.Logic
{
    public interface IMovieLogic
    {
        void Create(Movie item);
        void Delete(int id);
        double? GetAverageRatePerYear(int year);
        MovieViewDto Read(int id);
        IEnumerable<MovieViewDto> ReadAll();
        IEnumerable<YearStat> SummaryOfYears();
        void Update(Movie item);
    }
}