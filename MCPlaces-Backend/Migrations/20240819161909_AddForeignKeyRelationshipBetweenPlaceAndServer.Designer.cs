﻿// <auto-generated />
using MCPlaces_Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MCPlaces_Backend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240819161909_AddForeignKeyRelationshipBetweenPlaceAndServer")]
    partial class AddForeignKeyRelationshipBetweenPlaceAndServer
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("MCPlaces_Backend.Models.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CoordsX")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CoordsY")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CoordsZ")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ServerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ServerId");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("MCPlaces_Backend.Models.Server", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Patch")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Seed")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Servers");
                });

            modelBuilder.Entity("MCPlaces_Backend.Models.Place", b =>
                {
                    b.HasOne("MCPlaces_Backend.Models.Server", "Server")
                        .WithMany()
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Server");
                });
#pragma warning restore 612, 618
        }
    }
}
