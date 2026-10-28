using MovieManager.Models;
using MovieManager.Models.Dtos.Movie;
using MovieManager.Models.Entities;

namespace MovieManager.Logic
{
    public interface IMovieLogic
    {
        void Create(MovieCreateUpdateDto item);
        void Delete(int id);
        double? GetAverageRatePerYear(int year);
        MovieViewDto Read(int id);
        IEnumerable<MovieViewDto> ReadAll();
        IEnumerable<YearStat> SummaryOfYears();
        void Update(int id, MovieCreateUpdateDto item);
    }
}