﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RetroMarket.Models {

    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Adresse> Adresses { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Commentaire> Commentaires { get; set; }
        public DbSet<Compagnie> Compagnies { get; set; }
        public DbSet<TypeProduit> TypesProduit { get; set; }
        public DbSet<Purolator> Purolator { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public ApplicationDbContext()
        {
        }

        /*public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }*/


    }
}
