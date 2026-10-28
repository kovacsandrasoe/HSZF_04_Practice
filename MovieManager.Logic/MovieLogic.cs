using MovieManager.Models;
using MovieManager.Models.Dtos.Movie;
using MovieManager.Models.Entities;
using MovieManager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManager.Logic
{
    public class MovieLogic : IMovieLogic
    {
        IMovieRepository repository;
        public MovieLogic(IMovieRepository repository)
        {
            this.repository = repository;
        }
        public void Create(MovieCreateUpdateDto item)
        {
            if (item.Title.Length < 3)
            {
                throw new ArgumentException("Title too short!");
            }
            else
            {
                Movie m = new Movie();
                m.Title = item.Title;
                m.DirectorId = item.DirectorId;
                m.Release = item.Release;
                m.Income = item.Income;
                m.Rating = item.Rating;
                this.repository.Create(m);
            }
        }
        public MovieViewDto Read(int id)
        {
            var movie = this.repository.Read(id);
            if (movie == null)
            {
                throw new ArgumentException("Movie not exists");
            }

            var dto = new MovieViewDto();
            dto.Id = movie.Id;
            dto.Title = movie.Title;
            dto.Rating = movie.Rating;
            dto.Income = movie.Income;
            dto.Release = movie.Release;
            dto.DirectorName = movie.Director?.Name ?? "ismeretlen rendező";

            return dto;
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }
        public IEnumerable<MovieViewDto> ReadAll()
        {
            return this.repository.ReadAll().Select(t =>
                new MovieViewDto()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Rating = t.Rating,
                    Income = t.Income,
                    Release = t.Release,
                    DirectorName = t.Director!.Name
                });
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

        public IEnumerable<YearStat> SummaryOfYears()
        {
            return this.repository
                .ReadAll()
                .GroupBy(z => z.Release.Year)
                .Select(z => new YearStat
                (z.Key, z.Count(), z.Average(t => t.Rating)));
        }

    }
}
