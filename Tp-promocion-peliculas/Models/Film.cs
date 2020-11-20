using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tp_promocion_peliculas.Models
{
    public class Film
    {
        public int Id { get; set; }


        [Display(Name = "Nombre de pelicula")]
        [Required(ErrorMessage = "El campo es requerido")]
        public string Title { get; set; }


        [Display(Name = "Fecha de estreno")]
        [Required(ErrorMessage = "El campo es requerido")]
        public DateTime ReleaseDate { get; set; }


        [Display(Name = "Imagen de pelicula")]
        public string Photo { get; set; }


        [Display(Name = "Trailer(link)")]
        [Required(ErrorMessage = "El campo es requerido")]
        public string Trailer { get; set; }


        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "El campo es requerido")]
        public string Summary { get; set; }


        [Display(Name = "Genero")]
        [Required(ErrorMessage = "El campo es requerido")]
        public int? GenderId { get; set; }
        public Gender Genders { get; set; }


        [Display(Name = "En cartelera")]
        public bool billboard { get; set; }

        
        public List<MovieActor> MovieActors { get; set; }

    }
}
