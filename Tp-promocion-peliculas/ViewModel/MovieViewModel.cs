using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tp_promocion_peliculas.Models;

namespace Tp_promocion_peliculas.ViewModel
{
    public class MovieViewModel
    {
        public List<Film> Films { get; set; }
        public List<Person> Persons { get; set; }
        public List<MovieActor> MovieActors { get; set; }

        public SelectList ListGender { get; set; }
    }
}
