using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tp_promocion_peliculas.Models
{
    public class Gender
    {
        public int Id { get; set; }


        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo es requerido")]
        public string Description { get; set; }

        [Display(Name = "Nombre")]
        List<Gender> Genders { get; set; }
    }
}
