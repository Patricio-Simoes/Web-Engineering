﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FP_02_2021_2022.Migrations
{
    [DbContext(typeof(EW_2021_PAP1_DB_alXXXXX))]
    [Migration("20231103070722_SecondMigration")]
    partial class SecondMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FP_02_2021_2022.Models.Livro", b =>
                {
                    b.Property<string>("titulo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("autores")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("capa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contracapa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("editora")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("isbn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("titulo");

                    b.ToTable("Livro");
                });
#pragma warning restore 612, 618
        }
    }
}
