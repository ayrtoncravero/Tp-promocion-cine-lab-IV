using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tp_promocion_peliculas.Models
{
    public class MovieGender
    {
        [Display(Name = "Película")]
        public int FilmId { get; set; }

        [Display(Name = "Película")]
        public Film Film { get; set; }

        [Display(Name = "Género")]
        public int GenderId { get; set; }

        [Display(Name = "Género")]
        public Gender Gender { get; set; }
    }
}
