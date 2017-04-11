using Microsoft.EntityFrameworkCore;

namespace RetroMarket.Models {

    public class ApplicationDbContext : DbContext {

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Adresse> Adresses { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Commentaire> Commentaires { get; set; }
        public DbSet<Compagnie> Compagnies { get; set; }
        public DbSet<TypeProduit> TypesProduit { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        /*public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }*/
    }
}
