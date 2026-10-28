using Microsoft.AspNetCore.Mvc;
using MovieManager.Logic;
using MovieManager.Models;
using MovieManager.Models.Dtos.Movie;
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
        public IEnumerable<MovieViewDto> GetMovies()
        {
            return logic.ReadAll();
        }


        [HttpGet("{id}")]
        public MovieViewDto GetMovie(int id)
        {
            return logic.Read(id);
        }

        [HttpGet("year-stat")]
        public IEnumerable<YearStat> GetYearStat()
        {
            return logic.SummaryOfYears();
        }

        [HttpPost]
        public void CreateMovie([FromBody] MovieCreateUpdateDto m)
        {
            logic.Create(m);
        }


        [HttpDelete("{id}")]
        public void DeleteMovie(int id)
        {
            logic.Delete(id);
        }

        [HttpPut("{id}")]
        public void UpdateMovie(int id, [FromBody] MovieCreateUpdateDto dto)
        {
            logic.Update(id, dto);
        }

    }
}
