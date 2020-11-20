using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tp_promocion_peliculas.Models
{
    public class Person
    {
        public int Id { get; set; }


        [Display(Name = "Nombre de actor")]
        [Required(ErrorMessage = "El campo es requerido")]
        public string Name { get; set; }


        [Display(Name = "Fecha de nacimiento")]
        [Required(ErrorMessage = "El campo es requerido")]
        public DateTime Birthdate { get; set; }


        [Display(Name = "Biografia")]
        [Required(ErrorMessage = "El campo es requerido")]
        public string Biography { get; set; }


        [Display(Name = "Foto de actor")]
        public string Photo { get; set; }


        public List<MovieActor> MovieActors { get; set; }
    }
}
