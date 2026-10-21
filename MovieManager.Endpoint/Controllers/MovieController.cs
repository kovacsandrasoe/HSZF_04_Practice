using Microsoft.AspNetCore.Mvc;
using MovieManager.Logic;
using MovieManager.Models;

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
    }
}
