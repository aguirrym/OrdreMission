﻿// <auto-generated />
using System;
using GestionDordreDeMission.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace OrdreMission.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190322220621_AddedEmployEntity")]
    partial class AddedEmployEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085");

            modelBuilder.Entity("OrdreMission.API.Models.EmployeesRed", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FonctionEmp");

                    b.Property<string>("NOM");

                    b.Property<string>("NumPassport");

                    b.Property<string>("Prenom");

                    b.HasKey("Id");

                    b.ToTable("EmployeeRed");
                });

            modelBuilder.Entity("OrdreMission.API.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsMain");

                    b.Property<string>("Url");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("OrdreMission.API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Gender");

                    b.Property<string>("KnownAs");

                    b.Property<DateTime>("LastActive");

                    b.Property<string>("LookingFor");

                    b.Property<byte[]>("MotedepasseHash");

                    b.Property<byte[]>("Motedepassesalt");

                    b.Property<string>("Nom");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OrdreMission.API.Models.Value", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PostEmp");

                    b.HasKey("Id");

                    b.ToTable("Values");
                });

            modelBuilder.Entity("OrdreMission.API.Models.Photo", b =>
                {
                    b.HasOne("OrdreMission.API.Models.User", "User")
                        .WithMany("Photos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
