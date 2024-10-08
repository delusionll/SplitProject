﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using DAL;

#nullable disable

namespace SplitProject.DAL.Migrations
{
    [DbContext(typeof(SplitContext))]
    [Migration("20240903013237_db-fix-2")]
    partial class dbfix2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SplitProject.Domain.Models.Expense", b =>
                {
                    b.Property<Guid>("ExpenseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasPrecision(13, 2)
                        .HasColumnType("decimal(13,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ExpenseID");

                    b.HasIndex("UserID");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("SplitProject.Domain.Models.User", b =>
                {
                    b.Property<Guid>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Balance")
                        .HasPrecision(13, 2)
                        .HasColumnType("decimal(13,2)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SplitProject.Domain.Models.UserBenefiter", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasPrecision(13, 2)
                        .HasColumnType("decimal(13,2)");

                    b.Property<Guid>("ExpenseID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Share")
                        .HasColumnType("int");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("ExpenseID");

                    b.HasIndex("UserID");

                    b.ToTable("Benefiters");
                });

            modelBuilder.Entity("SplitProject.Domain.Models.Expense", b =>
                {
                    b.HasOne("SplitProject.Domain.Models.User", null)
                        .WithMany("Expenses")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SplitProject.Domain.Models.UserBenefiter", b =>
                {
                    b.HasOne("SplitProject.Domain.Models.Expense", null)
                        .WithMany("Benefiters")
                        .HasForeignKey("ExpenseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SplitProject.Domain.Models.User", "User")
                        .WithMany("Benefiters")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SplitProject.Domain.Models.Expense", b =>
                {
                    b.Navigation("Benefiters");
                });

            modelBuilder.Entity("SplitProject.Domain.Models.User", b =>
                {
                    b.Navigation("Benefiters");

                    b.Navigation("Expenses");
                });
#pragma warning restore 612, 618
        }
    }
}
