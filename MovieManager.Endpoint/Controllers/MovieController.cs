using Microsoft.AspNetCore.Mvc;
using MovieManager.Logic;
using MovieManager.Models;
using MovieManager.Models.Entities;

namespace MovieManager.Endpoint.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class MovieController : ControllerBase
    {
        IMovieLogic logic;
        public MovieController(IMovieLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Movie> GetMovies()
        {
            return logic.ReadAll();
        }


        [HttpGet("{id}")]
        public Movie GetMovie(int id)
        {
            return logic.Read(id);
        }

        [HttpGet("year-stat")]
        public IEnumerable<YearStat> GetYearStat() 
        {
            return logic.SummaryOfYears();
        }

        [HttpPost]
        public void CreateMovie([FromBody] Movie m)
        {
            logic.Create(m);
        }


        [HttpDelete("{id}")]
        public void DeleteMovie(int id)
        {
            logic.Delete(id);
        }

        [HttpPut]
        public void UpdateMovie([FromBody] Movie movie)
        {
            logic.Update(movie);
        }

    }
}
