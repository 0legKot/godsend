﻿// <auto-generated />
using Godsend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;

namespace Godsend.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20180525182004_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Godsend.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustomerId");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<DateTime?>("Done");

                    b.Property<DateTime>("Ordered");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Order");
                });

            modelBuilder.Entity("Godsend.Models.OrderPartDiscrete", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("OrderId");

                    b.Property<Guid?>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<Guid?>("SupplierId");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SupplierId");

                    b.ToTable("OrderPartDiscrete");
                });

            modelBuilder.Entity("Godsend.Models.OrderPartWeighted", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("OrderId");

                    b.Property<Guid?>("ProductId");

                    b.Property<Guid?>("SupplierId");

                    b.Property<double>("Weight");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SupplierId");

                    b.ToTable("OrderPartWeighted");
                });

            modelBuilder.Entity("Godsend.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<Guid?>("InfoId");

                    b.HasKey("Id");

                    b.HasIndex("InfoId");

                    b.ToTable("Products");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Product");
                });

            modelBuilder.Entity("Godsend.Models.ProductInformation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<double>("Rating");

                    b.Property<int>("Watches");

                    b.HasKey("Id");

                    b.ToTable("ProductInformation");
                });

            modelBuilder.Entity("Godsend.Models.Supplier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<Guid?>("InfoId");

                    b.HasKey("Id");

                    b.HasIndex("InfoId");

                    b.ToTable("Suppliers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Supplier");
                });

            modelBuilder.Entity("Godsend.Models.SupplierInformation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<double>("Rating");

                    b.Property<int>("Watches");

                    b.HasKey("Id");

                    b.ToTable("SupplierInformation");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("IdentityUser");
                });

            modelBuilder.Entity("Godsend.Models.SimpleOrder", b =>
                {
                    b.HasBaseType("Godsend.Models.Order");


                    b.ToTable("SimpleOrder");

                    b.HasDiscriminator().HasValue("SimpleOrder");
                });

            modelBuilder.Entity("Godsend.Models.DiscreteProduct", b =>
                {
                    b.HasBaseType("Godsend.Models.Product");


                    b.ToTable("DiscreteProduct");

                    b.HasDiscriminator().HasValue("DiscreteProduct");
                });

            modelBuilder.Entity("Godsend.Models.WeightedProduct", b =>
                {
                    b.HasBaseType("Godsend.Models.Product");


                    b.ToTable("WeightedProduct");

                    b.HasDiscriminator().HasValue("WeightedProduct");
                });

            modelBuilder.Entity("Godsend.Models.SimpleSupplier", b =>
                {
                    b.HasBaseType("Godsend.Models.Supplier");


                    b.ToTable("SimpleSupplier");

                    b.HasDiscriminator().HasValue("SimpleSupplier");
                });

            modelBuilder.Entity("Godsend.Models.Order", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("Godsend.Models.OrderPartDiscrete", b =>
                {
                    b.HasOne("Godsend.Models.Order")
                        .WithMany("DiscreteItems")
                        .HasForeignKey("OrderId");

                    b.HasOne("Godsend.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("Godsend.Models.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId");
                });

            modelBuilder.Entity("Godsend.Models.OrderPartWeighted", b =>
                {
                    b.HasOne("Godsend.Models.Order")
                        .WithMany("WeightedItems")
                        .HasForeignKey("OrderId");

                    b.HasOne("Godsend.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("Godsend.Models.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId");
                });

            modelBuilder.Entity("Godsend.Models.Product", b =>
                {
                    b.HasOne("Godsend.Models.ProductInformation", "Info")
                        .WithMany()
                        .HasForeignKey("InfoId");
                });

            modelBuilder.Entity("Godsend.Models.Supplier", b =>
                {
                    b.HasOne("Godsend.Models.SupplierInformation", "Info")
                        .WithMany()
                        .HasForeignKey("InfoId");
                });
#pragma warning restore 612, 618
        }
    }
}
