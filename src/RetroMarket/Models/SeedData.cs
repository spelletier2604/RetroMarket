using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace RetroMarket.Models {

    public static class SeedData {

        public static void EnsurePopulated(IApplicationBuilder app) {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            if (!context.Products.Any()) {
                context.Products.AddRange(
                    new Product {
                        Name = "PS2", Description = "Bonne vieille PS2, presque pas utilisée.",
                        Category = "Console", Price = 150, Poids = 20 },
                    new Product {
                        Name = "GameCube", 
                        Description = "Notre cube préféré", 
                        Category = "Console", Price = 75, Poids = 15 },
                    new Product {
                        Name = "Atari", 
                        Description = "Ouf, ça c'est vieux", 
                        Category = "Console", Price = 100, Poids = 12 },
                    new Product {
                        Name = "Super Smash Melee", 
                        Description = "Gamecube", 
                        Category = "Jeux", Price = 25,
                        Poids = 5
                    },
                    new Product {
                        Name = "Demon Souls", 
                        Description = "PS2", 
                        Category = "Jeux", Price = 20, Poids = 5 },
                    new Product {
                        Name = "Pong", 
                        Description = "Atari", 
                        Category = "Jeux", Price = 15,
                        Poids = 5
                    },
                    new Product {
                        Name = "Mannette PS2", 
                        Description = "Utilisée", 
                        Category = "Accessoire", Price = 30,
                        Poids = 5
                    },
                    new Product {
                        Name = "Mannette Gamecube", 
                        Description = "Neuve", 
                        Category = "Accessoire", Price = 50,
                        Poids = 5
                    },
                    new Product {
                        Name = "Cable HDMI", 
                        Description = "Toujours utile", 
                        Category = "Accessoire", Price = 10,
                        Poids = 5
                    }
                );
                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                context.Users.Add(new IdentityUser()
                {
                    Email = "admin@admin.ca",
                    PasswordHash = "AQAAAAEAACcQAAAAEI4zMV4+tIUkiWPjmrfMJyJN9bMLYWyvt4KONIPjgM1vYpTaD1E/PAb0VDJZRHCl0w==",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    UserName = "Admin",
                    NormalizedEmail = "ADMIN@ADMIN.CA",
                    NormalizedUserName = "ADMIN@ADMIN.CA",
                    SecurityStamp = "b332ef47-ba39-4be4-9ecd-43b4ad758fdc",
                    TwoFactorEnabled = false,
                    PhoneNumberConfirmed = false,
                    AccessFailedCount = 0
                });
                context.SaveChanges();
            }

            if (!context.Purolator.Any())
            {
                for (float f = 0.0f; f < 16; f++)
                {
                    context.Purolator.Add(new Purolator() {
                        MargedePoid = (int)f * 10,
                        Modificateur = 1 + (f/100)
                    });
                }
            }


            
        }
    }
}
