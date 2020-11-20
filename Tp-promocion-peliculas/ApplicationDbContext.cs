using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tp_promocion_peliculas.Models;

namespace Tp_promocion_peliculas
{
    //Clase que se encargara delm mapping de modelos a la BDD
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        //Para poder definir tablas con PK compartidas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MovieActor>().HasKey(x => new { x.PersonId, x.FilmId });
            modelBuilder.Entity<MovieGender>().HasKey(x => new { x.FilmId, x.GenderId });
        }

        //Tablas en plural - Modelos en singular
        public DbSet<Person> Persons { get; set; }
        public DbSet<Film> Movies { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<MovieGender> MovieGenders { get; set; }
    }
}
