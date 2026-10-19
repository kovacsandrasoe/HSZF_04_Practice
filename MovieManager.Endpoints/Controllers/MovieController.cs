using Microsoft.AspNetCore.Mvc;
using MovieManager.Logic;
using MovieManager.Models;
using MovieManager.Models.Dtos.Movie;

namespace MovieManager.Endpoints.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieLogic logic;

        public MovieController(IMovieLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<MovieViewDto> GetAllMovie()
        {
            return logic.ReadAll();
        }

        [HttpGet("{id}")]
        public MovieViewDto GetMovieById(int id)
        {
            return logic.Read(id);
        }

        [HttpDelete("{id}")]
        public void DeleteMovieById(int id)
        {
            logic.Delete(id);
        }

        [HttpPost]
        public void CreateMovie([FromBody] MovieCreateUpdateDto dto)
        {
            logic.Create(dto);
        }

        [HttpPut("{id}")]
        public void UpdateMovie(int id, [FromBody] MovieCreateUpdateDto movie)
        {
            logic.Update(id, movie);
        }

    }
}
