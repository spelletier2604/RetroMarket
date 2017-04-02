using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace RetroMarket.Models {

    public static class SeedData {

        public static void EnsurePopulated(IApplicationBuilder app) {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            if (!context.Products.Any()) {
                context.Products.AddRange(
                    new Product {
                        Name = "PS2", Description = "Bonne vieille PS2, presque pas utilisée.",
                        Category = "Console", Price = 150 },
                    new Product {
                        Name = "GameCube", 
                        Description = "Notre cube préféré", 
                        Category = "Console", Price = 75 },
                    new Product {
                        Name = "Atari", 
                        Description = "Ouf, ça c'est vieux", 
                        Category = "Console", Price = 100 },
                    new Product {
                        Name = "Super Smash Melee", 
                        Description = "Gamecube", 
                        Category = "Jeux", Price = 25 },
                    new Product {
                        Name = "Demon Souls", 
                        Description = "PS2", 
                        Category = "Jeux", Price = 20 },
                    new Product {
                        Name = "Pong", 
                        Description = "Atari", 
                        Category = "Jeux", Price = 15 },
                    new Product {
                        Name = "Mannette PS2", 
                        Description = "Utilisée", 
                        Category = "Accessoire", Price = 30 },
                    new Product {
                        Name = "Mannette Gamecube", 
                        Description = "Neuve", 
                        Category = "Accessoire", Price = 50 },
                    new Product {
                        Name = "Cable HDMI", 
                        Description = "Toujours utile", 
                        Category = "Accessoire", Price = 10
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
