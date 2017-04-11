﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using RetroMarket.Models;

namespace RetroMarket.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RetroMarket.Models.Adresse", b =>
                {
                    b.Property<int>("AdresseID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CodePostal")
                        .IsRequired();

                    b.Property<int>("NoCivic");

                    b.Property<string>("NoTelephone")
                        .IsRequired();

                    b.Property<string>("Province_Etat")
                        .IsRequired();

                    b.Property<string>("Rue")
                        .IsRequired();

                    b.Property<string>("Ville")
                        .IsRequired();

                    b.HasKey("AdresseID");

                    b.ToTable("Adresses");
                });

            modelBuilder.Entity("RetroMarket.Models.CartLine", b =>
                {
                    b.Property<int>("CartLineID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("OrderID");

                    b.Property<int?>("ProductID");

                    b.Property<int>("Quantity");

                    b.HasKey("CartLineID");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductID");

                    b.ToTable("CartLine");
                });

            modelBuilder.Entity("RetroMarket.Models.Categorie", b =>
                {
                    b.Property<int>("CategorieID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nom")
                        .IsRequired();

                    b.HasKey("CategorieID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("RetroMarket.Models.Commentaire", b =>
                {
                    b.Property<int>("CommentaireID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Corps")
                        .IsRequired();

                    b.Property<int>("Note");

                    b.Property<string>("Titre")
                        .IsRequired();

                    b.HasKey("CommentaireID");

                    b.ToTable("Commentaires");
                });

            modelBuilder.Entity("RetroMarket.Models.Compagnie", b =>
                {
                    b.Property<int>("CompagnieID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nom")
                        .IsRequired();

                    b.Property<string>("Pays")
                        .IsRequired();

                    b.HasKey("CompagnieID");

                    b.ToTable("Compagnies");
                });

            modelBuilder.Entity("RetroMarket.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("Country")
                        .IsRequired();

                    b.Property<bool>("GiftWrap");

                    b.Property<string>("Line1")
                        .IsRequired();

                    b.Property<string>("Line2");

                    b.Property<string>("Line3");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<bool>("Shipped");

                    b.Property<string>("State")
                        .IsRequired();

                    b.Property<string>("Zip");

                    b.HasKey("OrderID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("RetroMarket.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Category")
                        .IsRequired();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<bool>("Etat");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<decimal>("Price");

                    b.Property<int?>("TypeProduitID");

                    b.HasKey("ProductID");

                    b.HasIndex("TypeProduitID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("RetroMarket.Models.TypeProduit", b =>
                {
                    b.Property<int>("TypeProduitID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategorieID");

                    b.Property<int?>("CompagnieID");

                    b.Property<string>("Nom")
                        .IsRequired();

                    b.HasKey("TypeProduitID");

                    b.HasIndex("CategorieID");

                    b.HasIndex("CompagnieID");

                    b.ToTable("TypesProduit");
                });

            modelBuilder.Entity("RetroMarket.Models.CartLine", b =>
                {
                    b.HasOne("RetroMarket.Models.Order")
                        .WithMany("Lines")
                        .HasForeignKey("OrderID");

                    b.HasOne("RetroMarket.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID");
                });

            modelBuilder.Entity("RetroMarket.Models.Product", b =>
                {
                    b.HasOne("RetroMarket.Models.TypeProduit", "Type")
                        .WithMany()
                        .HasForeignKey("TypeProduitID");
                });

            modelBuilder.Entity("RetroMarket.Models.TypeProduit", b =>
                {
                    b.HasOne("RetroMarket.Models.Categorie", "Categ")
                        .WithMany("TypesProduit")
                        .HasForeignKey("CategorieID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RetroMarket.Models.Compagnie")
                        .WithMany("TypesProduit")
                        .HasForeignKey("CompagnieID");
                });
        }
    }
}
