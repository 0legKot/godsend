﻿// <auto-generated />
using System;
using Godsend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Godsend.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20180828203025_OrdersCompress")]
    partial class OrdersCompress
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Godsend.Models.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.HasKey("Id");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("Godsend.Models.ArticleInformation", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<int>("CommentsCount");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<string>("EFAuthorId");

                    b.Property<string>("Name");

                    b.Property<double>("Rating");

                    b.Property<int>("Watches");

                    b.HasKey("Id");

                    b.HasIndex("EFAuthorId");

                    b.ToTable("Articles");
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

            modelBuilder.Entity("Godsend.Models.EAV<decimal>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ProductId");

                    b.Property<Guid>("PropertyId");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("PropertyId");

                    b.ToTable("LinkProductPropertyDecimal");
                });

            modelBuilder.Entity("Godsend.Models.EAV<int>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ProductId");

                    b.Property<Guid>("PropertyId");

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

                    b.Property<Guid>("ProductId");

                    b.Property<Guid>("PropertyId");

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

            modelBuilder.Entity("Godsend.Models.LinkCommentEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("BaseCommentId");

                    b.Property<string>("Comment");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("BaseCommentId");

                    b.HasIndex("UserId");

                    b.ToTable("LinkCommentEntity");

                    b.HasDiscriminator<string>("Discriminator").HasValue("LinkCommentEntity");
                });

            modelBuilder.Entity("Godsend.Models.LinkProductsSuppliers", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("ProductId");

                    b.Property<Guid>("SupplierId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SupplierId");

                    b.ToTable("LinkProductsSuppliers");
                });

            modelBuilder.Entity("Godsend.Models.LinkRatingArticle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("EntityId");

                    b.Property<int>("Rating");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("EntityId");

                    b.HasIndex("UserId");

                    b.ToTable("LinkRatingArticle");
                });

            modelBuilder.Entity("Godsend.Models.LinkRatingProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("EntityId");

                    b.Property<int>("Rating");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("EntityId");

                    b.HasIndex("UserId");

                    b.ToTable("LinkRatingProduct");
                });

            modelBuilder.Entity("Godsend.Models.LinkRatingSupplier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("EntityId");

                    b.Property<int>("Rating");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("EntityId");

                    b.HasIndex("UserId");

                    b.ToTable("LinkRatingSupplier");
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

                    b.Property<Guid>("CategoryId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Godsend.Models.ProductInformation", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<int>("CommentsCount");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<double>("Rating");

                    b.Property<int>("State");

                    b.Property<int>("Watches");

                    b.HasKey("Id");

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

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Godsend.Models.SupplierInformation", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<int>("CommentsCount");

                    b.Property<Guid?>("LocationId");

                    b.Property<string>("Name");

                    b.Property<double>("Rating");

                    b.Property<int>("Watches");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

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
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

            modelBuilder.Entity("Godsend.Models.LinkCommentArticle", b =>
                {
                    b.HasBaseType("Godsend.Models.LinkCommentEntity");

                    b.Property<Guid>("ArticleId");

                    b.HasIndex("ArticleId");

                    b.ToTable("LinkCommentArticle");

                    b.HasDiscriminator().HasValue("LinkCommentArticle");
                });

            modelBuilder.Entity("Godsend.Models.LinkCommentProduct", b =>
                {
                    b.HasBaseType("Godsend.Models.LinkCommentEntity");

                    b.Property<Guid>("ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("LinkCommentProduct");

                    b.HasDiscriminator().HasValue("LinkCommentProduct");
                });

            modelBuilder.Entity("Godsend.Models.LinkCommentSupplier", b =>
                {
                    b.HasBaseType("Godsend.Models.LinkCommentEntity");

                    b.Property<Guid>("SupplierId");

                    b.HasIndex("SupplierId");

                    b.ToTable("LinkCommentSupplier");

                    b.HasDiscriminator().HasValue("LinkCommentSupplier");
                });

            modelBuilder.Entity("Godsend.Models.SimpleOrder", b =>
                {
                    b.HasBaseType("Godsend.Models.Order");


                    b.ToTable("SimpleOrder");

                    b.HasDiscriminator().HasValue("SimpleOrder");
                });

            modelBuilder.Entity("Godsend.Models.ArticleInformation", b =>
                {
                    b.HasOne("Godsend.Models.User", "EFAuthor")
                        .WithMany()
                        .HasForeignKey("EFAuthorId");

                    b.HasOne("Godsend.Models.Article", "Article")
                        .WithOne("Info")
                        .HasForeignKey("Godsend.Models.ArticleInformation", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Godsend.Models.Category", b =>
                {
                    b.HasOne("Godsend.Models.Category", "BaseCategory")
                        .WithMany()
                        .HasForeignKey("BaseCategoryId");
                });

            modelBuilder.Entity("Godsend.Models.EAV<decimal>", b =>
                {
                    b.HasOne("Godsend.Models.Product", "Product")
                        .WithMany("DecimalProps")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Godsend.Models.Property", "Property")
                        .WithMany()
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Godsend.Models.EAV<int>", b =>
                {
                    b.HasOne("Godsend.Models.Product", "Product")
                        .WithMany("IntProps")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Godsend.Models.Property", "Property")
                        .WithMany()
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Godsend.Models.EAV<string>", b =>
                {
                    b.HasOne("Godsend.Models.Product", "Product")
                        .WithMany("StringProps")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Godsend.Models.Property", "Property")
                        .WithMany()
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Godsend.Models.LinkCommentEntity", b =>
                {
                    b.HasOne("Godsend.Models.LinkCommentEntity", "BaseComment")
                        .WithMany("ChildComments")
                        .HasForeignKey("BaseCommentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Godsend.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Godsend.Models.LinkProductsSuppliers", b =>
                {
                    b.HasOne("Godsend.Models.Product", "Product")
                        .WithMany("LinkProductsSuppliers")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Godsend.Models.Supplier", "Supplier")
                        .WithMany("LinkProductsSuppliers")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Godsend.Models.LinkRatingArticle", b =>
                {
                    b.HasOne("Godsend.Models.Article", "Entity")
                        .WithMany()
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Godsend.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Godsend.Models.LinkRatingProduct", b =>
                {
                    b.HasOne("Godsend.Models.Product", "Entity")
                        .WithMany()
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Godsend.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Godsend.Models.LinkRatingSupplier", b =>
                {
                    b.HasOne("Godsend.Models.Supplier", "Entity")
                        .WithMany()
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Godsend.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
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

                    b.HasOne("Godsend.Models.ProductInformation", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Godsend.Models.SupplierInformation", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Godsend.Models.Product", b =>
                {
                    b.HasOne("Godsend.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Godsend.Models.ProductInformation", b =>
                {
                    b.HasOne("Godsend.Models.Product", "Product")
                        .WithOne("Info")
                        .HasForeignKey("Godsend.Models.ProductInformation", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
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

            modelBuilder.Entity("Godsend.Models.SupplierInformation", b =>
                {
                    b.HasOne("Godsend.Models.Supplier", "Supplier")
                        .WithOne("Info")
                        .HasForeignKey("Godsend.Models.SupplierInformation", "Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Godsend.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");
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

            modelBuilder.Entity("Godsend.Models.LinkCommentArticle", b =>
                {
                    b.HasOne("Godsend.Models.Article", "Article")
                        .WithMany()
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Godsend.Models.LinkCommentProduct", b =>
                {
                    b.HasOne("Godsend.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Godsend.Models.LinkCommentSupplier", b =>
                {
                    b.HasOne("Godsend.Models.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
