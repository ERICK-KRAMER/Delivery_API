﻿// <auto-generated />
using System;
using Delivery.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Delivery.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20240802185306_orderRelationsships")]
    partial class orderRelationsships
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Delivery.Models.Order", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uuid");

                    b.HasKey("ID");

                    b.HasIndex("ProductID");

                    b.HasIndex("UserID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Delivery.Models.Product", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Category")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<decimal>("DiscountPercent")
                        .HasColumnType("numeric");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("ID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Delivery.Models.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Delivery.Models.Order", b =>
                {
                    b.HasOne("Delivery.Models.Product", null)
                        .WithMany("Orders")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Delivery.Models.User", null)
                        .WithMany("Orders")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Delivery.Models.Product", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Delivery.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
