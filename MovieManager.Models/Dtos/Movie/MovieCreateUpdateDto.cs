using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManager.Models.Dtos.Movie
{
    public class MovieCreateUpdateDto
    {
        public string Title { get; set; } = string.Empty;
        public double Income { get; set; }
        public double Rating { get; set; }
        public DateTime Release { get; set; }
        public int DirectorId { get; set; }
    }
}
