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
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Godsend.Models.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<Guid?>("EntityInformationId");

                    b.Property<Guid?>("InfoId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("EntityInformationId");

                    b.HasIndex("InfoId");

                    b.ToTable("Articles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Article");
                });

            modelBuilder.Entity("Godsend.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("BaseCategoryId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("BaseCategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Godsend.Models.Cell", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BaseColumnId");

                    b.Property<int?>("DirId");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int?>("ValueId");

                    b.HasKey("Id");

                    b.HasIndex("BaseColumnId");

                    b.HasIndex("DirId");

                    b.HasIndex("ValueId");

                    b.ToTable("Values");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Cell");
                });

            modelBuilder.Entity("Godsend.Models.Column", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BaseClassId");

                    b.Property<string>("ColumnType");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("BaseClassId");

                    b.ToTable("Column");
                });

            modelBuilder.Entity("Godsend.Models.Directory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BaseId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("BaseId");

                    b.ToTable("Directory");
                });

            modelBuilder.Entity("Godsend.Models.EAV<decimal>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ProductId");

                    b.Property<Guid?>("PropertyId");

                    b.Property<decimal>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("PropertyId");

                    b.ToTable("LinkProductPropertyDecimal");
                });

            modelBuilder.Entity("Godsend.Models.EAV<int>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ProductId");

                    b.Property<Guid?>("PropertyId");

                    b.Property<int>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("PropertyId");

                    b.ToTable("LinkProductPropertyInt");
                });

            modelBuilder.Entity("Godsend.Models.EAV<string>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ProductId");

                    b.Property<Guid?>("PropertyId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("PropertyId");

                    b.ToTable("LinkProductPropertyString");
                });

            modelBuilder.Entity("Godsend.Models.ImagePaths", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Preview");

                    b.HasKey("Id");

                    b.ToTable("ImagePathsTable");
                });

            modelBuilder.Entity("Godsend.Models.Information", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Name");

                    b.Property<double>("Rating");

                    b.Property<int>("Watches");

                    b.HasKey("Id");

                    b.ToTable("Information");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Information");
                });

            modelBuilder.Entity("Godsend.Models.LinkProductsSuppliers", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Price");

                    b.Property<Guid>("ProductId");

                    b.Property<Guid>("SupplierId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SupplierId");

                    b.ToTable("LinkProductsSuppliers");
                });

            modelBuilder.Entity("Godsend.Models.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("Godsend.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<DateTime?>("Done");

                    b.Property<string>("EFCustomerId");

                    b.Property<DateTime>("Ordered");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("EFCustomerId");

                    b.ToTable("Orders");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Order");
                });

            modelBuilder.Entity("Godsend.Models.OrderPartProducts", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Multiplier");

                    b.Property<Guid?>("OrderId");

                    b.Property<Guid>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<Guid>("SupplierId");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SupplierId");

                    b.ToTable("OrderPartProducts");
                });

            modelBuilder.Entity("Godsend.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CategoryId");

                    b.Property<Guid?>("EntityInformationId");

                    b.Property<Guid?>("InfoId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("EntityInformationId");

                    b.HasIndex("InfoId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Godsend.Models.Property", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<Guid?>("RelatedCategoryId");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("RelatedCategoryId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("Godsend.Models.Role", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Godsend.Models.StringWrapper", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ArticleInformationId");

                    b.Property<Guid?>("ImagePathsId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ArticleInformationId");

                    b.HasIndex("ImagePathsId");

                    b.ToTable("StringWrapper");
                });

            modelBuilder.Entity("Godsend.Models.Supplier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("EntityInformationId");

                    b.Property<Guid?>("InfoId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("EntityInformationId");

                    b.HasIndex("InfoId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Godsend.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<DateTime>("Birth");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<int>("Rating");

                    b.Property<DateTime>("RegistrationDate");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Godsend.Models.SimpleArticle", b =>
                {
                    b.HasBaseType("Godsend.Models.Article");


                    b.ToTable("SimpleArticle");

                    b.HasDiscriminator().HasValue("SimpleArticle");
                });

            modelBuilder.Entity("Godsend.Models.PrimitiveData", b =>
                {
                    b.HasBaseType("Godsend.Models.Cell");

                    b.Property<string>("RealData");

                    b.ToTable("PrimitiveData");

                    b.HasDiscriminator().HasValue("PrimitiveData");
                });

            modelBuilder.Entity("Godsend.Models.ArticleInformation", b =>
                {
                    b.HasBaseType("Godsend.Models.Information");

                    b.Property<DateTime>("Created");

                    b.Property<string>("EFAuthorId");

                    b.HasIndex("EFAuthorId");

                    b.ToTable("ArticleInformation");

                    b.HasDiscriminator().HasValue("ArticleInformation");
                });

            modelBuilder.Entity("Godsend.Models.ProductInformation", b =>
                {
                    b.HasBaseType("Godsend.Models.Information");

                    b.Property<string>("Description");

                    b.Property<int>("State");

                    b.ToTable("ProductInformation");

                    b.HasDiscriminator().HasValue("ProductInformation");
                });

            modelBuilder.Entity("Godsend.Models.SupplierInformation", b =>
                {
                    b.HasBaseType("Godsend.Models.Information");

                    b.Property<Guid?>("LocationId");

                    b.HasIndex("LocationId");

                    b.ToTable("SupplierInformation");

                    b.HasDiscriminator().HasValue("SupplierInformation");
                });

            modelBuilder.Entity("Godsend.Models.SimpleOrder", b =>
                {
                    b.HasBaseType("Godsend.Models.Order");


                    b.ToTable("SimpleOrder");

                    b.HasDiscriminator().HasValue("SimpleOrder");
                });

            modelBuilder.Entity("Godsend.Models.Article", b =>
                {
                    b.HasOne("Godsend.Models.Information", "EntityInformation")
                        .WithMany()
                        .HasForeignKey("EntityInformationId");

                    b.HasOne("Godsend.Models.ArticleInformation", "Info")
                        .WithMany()
                        .HasForeignKey("InfoId");
                });

            modelBuilder.Entity("Godsend.Models.Category", b =>
                {
                    b.HasOne("Godsend.Models.Category", "BaseCategory")
                        .WithMany()
                        .HasForeignKey("BaseCategoryId");
                });

            modelBuilder.Entity("Godsend.Models.Cell", b =>
                {
                    b.HasOne("Godsend.Models.Column", "BaseColumn")
                        .WithMany()
                        .HasForeignKey("BaseColumnId");

                    b.HasOne("Godsend.Models.Directory", "Dir")
                        .WithMany()
                        .HasForeignKey("DirId");

                    b.HasOne("Godsend.Models.PrimitiveData", "Value")
                        .WithMany()
                        .HasForeignKey("ValueId");
                });

            modelBuilder.Entity("Godsend.Models.Column", b =>
                {
                    b.HasOne("Godsend.Models.Directory", "BaseClass")
                        .WithMany()
                        .HasForeignKey("BaseClassId");
                });

            modelBuilder.Entity("Godsend.Models.Directory", b =>
                {
                    b.HasOne("Godsend.Models.Directory", "Base")
                        .WithMany()
                        .HasForeignKey("BaseId");
                });

            modelBuilder.Entity("Godsend.Models.EAV<decimal>", b =>
                {
                    b.HasOne("Godsend.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("Godsend.Models.Property", "Property")
                        .WithMany()
                        .HasForeignKey("PropertyId");
                });

            modelBuilder.Entity("Godsend.Models.EAV<int>", b =>
                {
                    b.HasOne("Godsend.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("Godsend.Models.Property", "Property")
                        .WithMany()
                        .HasForeignKey("PropertyId");
                });

            modelBuilder.Entity("Godsend.Models.EAV<string>", b =>
                {
                    b.HasOne("Godsend.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("Godsend.Models.Property", "Property")
                        .WithMany()
                        .HasForeignKey("PropertyId");
                });

            modelBuilder.Entity("Godsend.Models.LinkProductsSuppliers", b =>
                {
                    b.HasOne("Godsend.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Godsend.Models.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Godsend.Models.Order", b =>
                {
                    b.HasOne("Godsend.Models.User", "EFCustomer")
                        .WithMany()
                        .HasForeignKey("EFCustomerId");
                });

            modelBuilder.Entity("Godsend.Models.OrderPartProducts", b =>
                {
                    b.HasOne("Godsend.Models.Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId");

                    b.HasOne("Godsend.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Godsend.Models.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Godsend.Models.Product", b =>
                {
                    b.HasOne("Godsend.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("Godsend.Models.Information", "EntityInformation")
                        .WithMany()
                        .HasForeignKey("EntityInformationId");

                    b.HasOne("Godsend.Models.ProductInformation", "Info")
                        .WithMany()
                        .HasForeignKey("InfoId");
                });

            modelBuilder.Entity("Godsend.Models.Property", b =>
                {
                    b.HasOne("Godsend.Models.Category", "RelatedCategory")
                        .WithMany()
                        .HasForeignKey("RelatedCategoryId");
                });

            modelBuilder.Entity("Godsend.Models.StringWrapper", b =>
                {
                    b.HasOne("Godsend.Models.ArticleInformation")
                        .WithMany("EFTags")
                        .HasForeignKey("ArticleInformationId");

                    b.HasOne("Godsend.Models.ImagePaths")
                        .WithMany("Images")
                        .HasForeignKey("ImagePathsId");
                });

            modelBuilder.Entity("Godsend.Models.Supplier", b =>
                {
                    b.HasOne("Godsend.Models.Information", "EntityInformation")
                        .WithMany()
                        .HasForeignKey("EntityInformationId");

                    b.HasOne("Godsend.Models.SupplierInformation", "Info")
                        .WithMany()
                        .HasForeignKey("InfoId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Godsend.Models.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Godsend.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Godsend.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Godsend.Models.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Godsend.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Godsend.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Godsend.Models.ArticleInformation", b =>
                {
                    b.HasOne("Godsend.Models.User", "EFAuthor")
                        .WithMany()
                        .HasForeignKey("EFAuthorId");
                });

            modelBuilder.Entity("Godsend.Models.SupplierInformation", b =>
                {
                    b.HasOne("Godsend.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");
                });
#pragma warning restore 612, 618
        }
    }
}
