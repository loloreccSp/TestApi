﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestApiMovie.Data.Context;

#nullable disable

namespace TestApiMovie.Data.Migrations
{
    [DbContext(typeof(TestApiMovieContext))]
    partial class TestApiMovieContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestApiMovie.Data.Entites.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartId"));

                    b.Property<int?>("CartProductProductId")
                        .HasColumnType("int");

                    b.HasKey("CartId");

                    b.HasIndex("CartProductProductId");

                    b.ToTable("Cart", (string)null);
                });

            modelBuilder.Entity("TestApiMovie.Data.Entites.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId");

                    b.HasIndex("ProductId");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("TestApiMovie.Data.Entites.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<int?>("CustomerCartCartId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CustomerCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("CustomerLogin")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CustomerPhone")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("CustomerId");

                    b.HasIndex("CustomerCartCartId");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("TestApiMovie.Data.Entites.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("OrderAmout")
                        .HasColumnType("int");

                    b.Property<decimal>("OrderTotal")
                        .HasColumnType("decimal(18,8)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("TestApiMovie.Data.Entites.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,8)");

                    b.Property<DateTime>("ProductCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("ProductId");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("TestApiMovie.Data.Entites.Cart", b =>
                {
                    b.HasOne("TestApiMovie.Data.Entites.Product", "CartProduct")
                        .WithMany()
                        .HasForeignKey("CartProductProductId");

                    b.Navigation("CartProduct");
                });

            modelBuilder.Entity("TestApiMovie.Data.Entites.Category", b =>
                {
                    b.HasOne("TestApiMovie.Data.Entites.Product", null)
                        .WithMany("ProductCategory")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("TestApiMovie.Data.Entites.Customer", b =>
                {
                    b.HasOne("TestApiMovie.Data.Entites.Cart", "CustomerCart")
                        .WithMany()
                        .HasForeignKey("CustomerCartCartId");

                    b.Navigation("CustomerCart");
                });

            modelBuilder.Entity("TestApiMovie.Data.Entites.Order", b =>
                {
                    b.HasOne("TestApiMovie.Data.Entites.Customer", null)
                        .WithMany("CustomerOrder")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TestApiMovie.Data.Entites.Customer", b =>
                {
                    b.Navigation("CustomerOrder");
                });

            modelBuilder.Entity("TestApiMovie.Data.Entites.Product", b =>
                {
                    b.Navigation("ProductCategory");
                });
#pragma warning restore 612, 618
        }
    }
}