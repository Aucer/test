﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using test.Data;

#nullable disable

namespace test.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230802142832_Create_Table_Student")]
    partial class Create_Table_Student
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("test.Models.Person1", b =>
                {
                    b.Property<string>("PersonID")
                        .HasColumnType("TEXT");

                    b.Property<string>("PersonName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PersonID");

                    b.ToTable("Person1");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("test.Models.Student", b =>
                {
                    b.HasBaseType("test.Models.Person1");

                    b.Property<string>("StudentID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("test.Models.Student", b =>
                {
                    b.HasOne("test.Models.Person1", null)
                        .WithOne()
                        .HasForeignKey("test.Models.Student", "PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
