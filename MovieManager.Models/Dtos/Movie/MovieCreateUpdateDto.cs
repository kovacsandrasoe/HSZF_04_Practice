using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManager.Models.Dtos.Movie
{
    public class MovieCreateUpdateDto
    {
        [Required]
        [StringLength(240)]
        public string Title { get; set; } = string.Empty;

        [Range(0, 10000)]
        public double Income { get; set; }

        [Range(0, 10)]
        public double Rating { get; set; }

        public DateTime Release { get; set; }

        public int DirectorId { get; set; }
    }
}
