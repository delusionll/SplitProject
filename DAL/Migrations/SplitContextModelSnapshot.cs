﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace SplitProject.DAL.Migrations
{
    [DbContext(typeof(SplitContext))]
    partial class SplitContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Expense", b =>
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

            modelBuilder.Entity("Domain.User", b =>
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

            modelBuilder.Entity("Domain.UserBenefiter", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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

            modelBuilder.Entity("Domain.Expense", b =>
                {
                    b.HasOne("Domain.User", null)
                        .WithMany("Expenses")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.UserBenefiter", b =>
                {
                    b.HasOne("Domain.Expense", null)
                        .WithMany("Benefiters")
                        .HasForeignKey("ExpenseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.User", "User")
                        .WithMany("Benefiters")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Expense", b =>
                {
                    b.Navigation("Benefiters");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Navigation("Benefiters");

                    b.Navigation("Expenses");
                });
#pragma warning restore 612, 618
        }
    }
}
