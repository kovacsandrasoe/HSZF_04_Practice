using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MovieManager.Models.Dtos.Movie
{
    public class MovieViewDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public double Income { get; set; }
        public double Rating { get; set; }
        public DateTime Release { get; set; }
        public string DirectorName { get; set; } = string.Empty;

    }
}
