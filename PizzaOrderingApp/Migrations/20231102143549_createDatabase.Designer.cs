﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaOrderingApp;

#nullable disable

namespace PizzaOrderingApp.Migrations
{
    [DbContext(typeof(PizzaOrderingDbContext))]
    [Migration("20231102143549_createDatabase")]
    partial class createDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("PizzaOrderingApp.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PhoneNr")
                        .HasColumnType("INTEGER");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("PizzaOrderingApp.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("PizzaOrderingApp.Entities.Pizza", b =>
                {
                    b.Property<int>("PizzaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("PizzaName")
                        .HasColumnType("TEXT");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.HasKey("PizzaId");

                    b.ToTable("Pizza");
                });

            modelBuilder.Entity("PizzaOrderingApp.Entities.Pizza_Order", b =>
                {
                    b.Property<int>("PizzaOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PizzaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PizzaOrderId");

                    b.HasIndex("OrderId");

                    b.HasIndex("PizzaId");

                    b.ToTable("Pizza_Order");
                });

            modelBuilder.Entity("PizzaOrderingApp.Entities.Order", b =>
                {
                    b.HasOne("PizzaOrderingApp.Entities.Customer", "Customer")
                        .WithMany("Order")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("PizzaOrderingApp.Entities.Pizza_Order", b =>
                {
                    b.HasOne("PizzaOrderingApp.Entities.Order", "Order")
                        .WithMany("Pizza_Order")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaOrderingApp.Entities.Pizza", "Pizza")
                        .WithMany("Pizza_Order")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("PizzaOrderingApp.Entities.Customer", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("PizzaOrderingApp.Entities.Order", b =>
                {
                    b.Navigation("Pizza_Order");
                });

            modelBuilder.Entity("PizzaOrderingApp.Entities.Pizza", b =>
                {
                    b.Navigation("Pizza_Order");
                });
#pragma warning restore 612, 618
        }
    }
}
