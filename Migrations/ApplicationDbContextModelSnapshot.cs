﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using test.Data;

#nullable disable

namespace test.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("test.Models.Person1", b =>
                {
                    b.Property<string>("PersonID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PersonName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PersonID");

                    b.ToTable("Person1");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person1");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("test.Models.Cusmer", b =>
                {
                    b.HasBaseType("test.Models.Person1");

                    b.Property<string>("CusmerID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CusmerName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.ToTable("Person1");

                    b.HasDiscriminator().HasValue("Cusmer");
                });
#pragma warning restore 612, 618
        }
    }
}
