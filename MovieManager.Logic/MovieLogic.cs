using MovieManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManager.Logic
{
    public class MovieLogic
    {
        IRepository<Movie> repository;
        public MovieLogic(IRepository<Movie> repository)
        {
            this.repository = repository;
        }
        public void Create(Movie item)
        {
            if (item.Title.Length < 3)
            {
                throw new ArgumentException("Title too short!");
            }
            else
            {
                this.repository.Create(item);
            }
        }
        public Movie Read(int id)
        {
            var movie = this.repository.Read(id);
            if (movie == null)
            {
                throw new ArgumentException("Movie not exists");
            }
            return movie;
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }
        public IEnumerable<Movie> ReadAll()
        {
            return this.repository.ReadAll();
        }
        public void Update(Movie item)
        {
            this.repository.Update(item);
        }
        public double? GetAverageRatePerYear(int year)
        {
            return this.repository
            .ReadAll()
            .Where(t => t.Release.Year == year)
            .Average(t => t.Rating);
        }

    }
}
