﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tp_promocion_peliculas;

namespace Tp_promocion_peliculas.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201119153618_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Tp_promocion_peliculas.Models.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("GenderId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Trailer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("billboard")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Tp_promocion_peliculas.Models.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("Tp_promocion_peliculas.Models.MovieActor", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.HasKey("PersonId", "FilmId");

                    b.HasIndex("FilmId");

                    b.ToTable("MovieActors");
                });

            modelBuilder.Entity("Tp_promocion_peliculas.Models.MovieGender", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.HasKey("FilmId", "GenderId");

                    b.HasIndex("GenderId");

                    b.ToTable("MovieGenders");
                });

            modelBuilder.Entity("Tp_promocion_peliculas.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Tp_promocion_peliculas.Models.Film", b =>
                {
                    b.HasOne("Tp_promocion_peliculas.Models.Gender", "Genders")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genders");
                });

            modelBuilder.Entity("Tp_promocion_peliculas.Models.MovieActor", b =>
                {
                    b.HasOne("Tp_promocion_peliculas.Models.Film", "Film")
                        .WithMany("MovieActors")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tp_promocion_peliculas.Models.Person", "Person")
                        .WithMany("MovieActors")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Tp_promocion_peliculas.Models.MovieGender", b =>
                {
                    b.HasOne("Tp_promocion_peliculas.Models.Film", "Film")
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tp_promocion_peliculas.Models.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("Tp_promocion_peliculas.Models.Film", b =>
                {
                    b.Navigation("MovieActors");
                });

            modelBuilder.Entity("Tp_promocion_peliculas.Models.Person", b =>
                {
                    b.Navigation("MovieActors");
                });
#pragma warning restore 612, 618
        }
    }
}
