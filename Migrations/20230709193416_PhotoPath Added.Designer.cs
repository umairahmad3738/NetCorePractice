﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using kudvenkitPractice.DAL;

#nullable disable

namespace kudvenkitPractice.Migrations
{
    [DbContext(typeof(appDbContext))]
    [Migration("20230709193416_PhotoPath Added")]
    partial class PhotoPathAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("kudvenkitPractice.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Department")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhotoPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Department = 6,
                            Email = "umairtahir@gmail.com",
                            Gender = 0,
                            Name = "Umair",
                            PhotoPath = ""
                        },
                        new
                        {
                            Id = 2,
                            Department = 6,
                            Email = "Ammara.tahir@gmail.com",
                            Gender = 1,
                            Name = "Ammara",
                            PhotoPath = ""
                        },
                        new
                        {
                            Id = 3,
                            Department = 6,
                            Email = "Uzair.tahir@gmail.com",
                            Gender = 0,
                            Name = "Uzair",
                            PhotoPath = ""
                        },
                        new
                        {
                            Id = 4,
                            Department = 6,
                            Email = "Ayesha.tahir@gmail.com",
                            Gender = 1,
                            Name = "Ayesha",
                            PhotoPath = ""
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
