using RetroMarket.Controllers;
using RetroMarket.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RetroMarket.Tests
{
    public class TestPosteCanada
    {
        [Fact]
        public void EnvoyerDifferentLocation()
        {
            // Arrange
            OrderController controller = new OrderController(new EFOrderRepository(new ApplicationDbContext()), new Cart(), new ApplicationDbContext());
            //controller.CalculTransportPosteCanada()
            Models.Product p = new Models.Product() { Name = "Test", Price = 100, Poids = 10 };
            Cart cart = new Cart();
            cart.AddItem(p, 1);
            string[] locations = new string[5];
            locations[0] = "J3H4R7";
            locations[1] = "J3G4Y8";
            locations[2] = "A1A1A1";
            locations[3] = "K1A0B1";
            locations[4] = "V3H4Y8";

            foreach (string item in locations)
            {
                // Act
                switch (item)
                {
                    case "J3H4R7":
                        // Assert
                        Assert.Equal(controller.CalculTransportPosteCanada(cart, item), 20.24f);
                        break;
                    case "J3G4Y8":
                        // Assert
                        Assert.Equal(controller.CalculTransportPosteCanada(cart, item), 20.24f);
                        break;
                    case "A1A1A1":
                        // Assert
                        Assert.Equal(controller.CalculTransportPosteCanada(cart, item), 31.26f);
                        break;
                    case "K1A0B1":
                        // Assert
                        Assert.Equal(controller.CalculTransportPosteCanada(cart, item), 19.89f);
                        break;
                    case "V3H4Y8":
                        // Assert
                        Assert.Equal(controller.CalculTransportPosteCanada(cart, item), 28.54f);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
