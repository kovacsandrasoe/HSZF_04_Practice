using MovieManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManager.Repository
{
    public class MovieRepository : IMovieRepository 
    { 
        MovieDbContext context; 
        public MovieRepository(MovieDbContext context) 
        { 
            this.context = context;
        } 
        
        public void Create(Movie movie) 
        { 
            this.context.Movies.Add(movie); 
            this.context.SaveChanges(); 
        } 
        
        public void Delete(int id) 
        { 
            this.context.Movies.Remove(Read(id));
            this.context.SaveChanges(); 
        }

        public Movie Read(int id) 
        { 
            return this.context.Movies.FirstOrDefault(t => t.MovieId == id);
        }

        public IQueryable<Movie> ReadAll() 
        { 
            return this.context.Movies;
        }

        public void Update(Movie movie) 
        { 
            var oldmovie = Read(movie.MovieId);
            oldmovie.Income = movie.Income;
            oldmovie.Rating = movie.Rating;
            oldmovie.DirectorId = movie.DirectorId;
            oldmovie.Release = movie.Release; 
            oldmovie.Title = movie.Title; 
            this.context.SaveChanges(); 
        }
    }
}
