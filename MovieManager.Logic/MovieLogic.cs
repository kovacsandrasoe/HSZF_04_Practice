using MovieManager.Models;
using MovieManager.Models.Dtos.Movie;
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
        public void Create(MovieCreateUpdateDto dto)
        {
            if (dto.Title.Length < 3)
            {
                throw new ArgumentException("Title too short!");
            }
            else
            {
                Movie m = new Movie();
                m.Title = dto.Title;
                m.Release = dto.Release;
                m.Income = dto.Income;
                m.DirectorId = dto.DirectorId;
                m.Rating = dto.Rating;
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
            dto.DirectorName = movie.Director?.Name ?? string.Empty;
            dto.Rating = movie.Rating;
            dto.Release = movie.Release;
            dto.Income = movie.Income;

            return dto;
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }
        public IEnumerable<MovieViewDto> ReadAll()
        {
            return this.repository.ReadAll().Select(z => new MovieViewDto()
            {
                Id = z.Id,
                Title = z.Title,
                DirectorName = z.Director!.Name,
                Rating = z.Rating,
                Release = z.Release,
                Income = z.Income
            });
        }
        public void Update(int id, MovieCreateUpdateDto dto)
        {
            var old = this.repository.Read(id);
            old.Title = dto.Title;
            old.DirectorId = dto.DirectorId;
            old.Income = dto.Income;
            old.Rating = dto.Rating;
            old.Release = dto.Release;
            this.repository.Update(old);
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
