﻿// <auto-generated />
using EFTest2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFTest2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230514141703_PhoneNumberTo15")]
    partial class PhoneNumberTo15
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EFTest2.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("pracownicy");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Zielona 2",
                            Email = "jk@gmail.com",
                            Name = "Jan Kowalski"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Niebieska 13",
                            Email = "an@gmail.com",
                            Name = "Adam Nowak"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
