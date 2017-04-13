using System;
using Xunit;
using RetroMarket.Models;

namespace RetroMarket.Tests
{
    public class TestTaxes
    {
        [Fact]
        public void EnvoyerDuQuebec()
        {
            // Arrange
            Product p = new Product() { Name = "Test", Price = 100 };
            TaxesCanada.Abbre origine = TaxesCanada.Abbre.QC;
            foreach (TaxesCanada.Abbre item in Enum.GetValues(typeof(TaxesCanada.Abbre)))
            {
                TaxesCanada t = new TaxesCanada(item);
                // Act
                switch (item)
                {
                    case TaxesCanada.Abbre.AB:
                        // Assert
                        Assert.Equal(item == origine ? (float)p.Price * (1 + t.GST + t.PST) : (float)p.Price * (1 + t.GST)
                            , item != origine ? 105.0f : 105.0f, 2);
                        break;
                    case TaxesCanada.Abbre.BC:
                        // Assert
                        Assert.Equal(item == origine ? (float)p.Price * (1 + t.GST + t.PST) : (float)p.Price * (1 + t.GST)
                            , item != origine ? 105.0f : 112.0f, 2);
                        break;
                    case TaxesCanada.Abbre.MB:
                        // Assert
                        Assert.Equal(item == origine ? (float)p.Price * (1 + t.GST + t.PST) : (float)p.Price * (1 + t.GST)
                            , item != origine ? 105.0f : 113.0f, 2);
                        break;
                    case TaxesCanada.Abbre.NB:
                        // Assert
                        Assert.Equal(item == origine ? (float)p.Price * (1 + t.GST + t.PST) : (float)p.Price * (1 + t.GST)
                            , item != origine ? 115.0f : 115.0f, 2);
                        break;
                    case TaxesCanada.Abbre.NL:
                        // Assert
                        Assert.Equal(item == origine ? (float)p.Price * (1 + t.GST + t.PST) : (float)p.Price * (1 + t.GST)
                            , item != origine ? 115.0f : 115.0f, 2);
                        break;
                    case TaxesCanada.Abbre.NT:
                        // Assert
                        Assert.Equal(item == origine ? (float)p.Price * (1 + t.GST + t.PST) : (float)p.Price * (1 + t.GST)
                            , item != origine ? 105.0f : 105.0f, 2);
                        break;
                    case TaxesCanada.Abbre.NS:
                        // Assert
                        Assert.Equal(item == origine ? (float)p.Price * (1 + t.GST + t.PST) : (float)p.Price * (1 + t.GST)
                            , item != origine ? 115.0f : 115.0f, 2);
                        break;
                    case TaxesCanada.Abbre.NU:
                        // Assert
                        Assert.Equal(item == origine ? (float)p.Price * (1 + t.GST + t.PST) : (float)p.Price * (1 + t.GST)
                            , item != origine ? 105.0f : 105.0f, 2);
                        break;
                    case TaxesCanada.Abbre.PE:
                        // Assert
                        Assert.Equal(item == origine ? (float)p.Price * (1 + t.GST + t.PST) : (float)p.Price * (1 + t.GST)
                            , item != origine ? 115.0f : 115.0f, 2);
                        break;
                    case TaxesCanada.Abbre.ON:
                        // Assert
                        Assert.Equal(item == origine ? (float)p.Price * (1 + t.GST + t.PST) : (float)p.Price * (1 + t.GST)
                            , item != origine ? 113.0f : 113.0f, 2);
                        break;
                    case TaxesCanada.Abbre.QC:
                        // Assert
                        Assert.Equal(item == origine ? (float)p.Price * (1 + t.GST + t.PST) : (float)p.Price * (1 + t.GST)
                            , item != origine ? 105.0f : 115.0f, 2);
                        break;
                    case TaxesCanada.Abbre.SK:
                        // Assert
                        Assert.Equal(item == origine ? (float)p.Price * (1 + t.GST + t.PST) : (float)p.Price * (1 + t.GST)
                            , item != origine ? 105.0f : 111.0f, 2);
                        break;
                    case TaxesCanada.Abbre.YT:
                        // Assert
                        Assert.Equal(item == origine ? (float)p.Price * (1 + t.GST + t.PST) : (float)p.Price * (1 + t.GST)
                            , item != origine ? 105.0f : 105.0f, 2);
                        break;
                    case TaxesCanada.Abbre.Autre:
                        // Assert
                        Assert.Equal(item == origine ? (float)p.Price * (1 + t.GST + t.PST) : (float)p.Price * (1 + t.GST)
                            , item != origine ? 100.0f : 100.0f, 2);
                        break;
                    default:
                        break;
                }
            }
        }
        
        [Fact]
        public void EnvoyerDeLOntario()
        {
            // Arrange
            Product p = new Product() { Name = "Test", Price = 100 };
            TaxesCanada.Abbre origine = TaxesCanada.Abbre.ON;

            foreach (TaxesCanada.Abbre item in Enum.GetValues(typeof(TaxesCanada.Abbre)))
            {
                TaxesCanada t = new TaxesCanada(item);
                // Act
                switch (item)
                {
                    case TaxesCanada.Abbre.AB:
                        // Assert
                        Assert.Equal(item == origine ? (float)p.Price * (1 + t.GST + t.PST) : (float)p.Price * (1 + t.GST)
                            , item != origine ? 105.0f : 105.0f, 2);
                        break;
                    case TaxesCanada.Abbre.BC:
                        // Assert
                        Assert.Equal(item == origine ? (float)p.Price * (1 + t.GST + t.PST) : (float)p.Price * (1 + t.GST)
                            , item != origine ? 105.0f : 112.0f, 2);
                        break;
                    case TaxesCanada.Abbre.MB:
                        // Assert
                        Assert.Equal(item == origine ? (float)p.Price * (1 + t.GST + t.PST) : (float)p.Price * (1 + t.GST)
                            , item != origine ? 105.0f : 113.0f, 2);
                        break;
                    case TaxesCanada.Abbre.NB:
                        // Assert
                        Assert.Equal(item == origine ? (float)p.Price * (1 + t.GST + t.PST) : (float)p.Price * (1 + t.GST)
                            , item != origine ? 115.0f : 115.0f, 2);
                        break;
                    case TaxesCanada.Abbre.NL:
                        // Assert
                        Assert.Equal(item == origine ? (float)p.Price * (1 + t.GST + t.PST) : (float)p.Price * (1 + t.GST)
                            , item != origine ? 115.0f : 115.0f, 2);
                        break;
                    case TaxesCanada.Abbre.NT:
                        // Assert
                        Assert.Equal(item == origine ? (float)p.Price * (1 + t.GST + t.PST) : (float)p.Price * (1 + t.GST)
                            , item != origine ? 105.0f : 105.0f, 2);
                        break;
                    case TaxesCanada.Abbre.NS:
                        // Assert
                        Assert.Equal(item == origine ? (float)p.Price * (1 + t.GST + t.PST) : (float)p.Price * (1 + t.GST)
                            , item != origine ? 115.0f : 115.0f, 2);
                        break;
                    case TaxesCanada.Abbre.NU:
                        // Assert
                        Assert.Equal(item == origine ? (float)p.Price * (1 + t.GST + t.PST) : (float)p.Price * (1 + t.GST)
                            , item != origine ? 105.0f : 105.0f, 2);
                        break;
                    case TaxesCanada.Abbre.PE:
                        // Assert
                        Assert.Equal(item == origine ? (float)p.Price * (1 + t.GST + t.PST) : (float)p.Price * (1 + t.GST)
                            , item != origine ? 115.0f : 115.0f, 2);
                        break;
                    case TaxesCanada.Abbre.ON:
                        // Assert
                        Assert.Equal(item == origine ? (float)p.Price * (1 + t.GST + t.PST) : (float)p.Price * (1 + t.GST)
                            , item != origine ? 113.0f : 113.0f, 2);
                        break;
                    case TaxesCanada.Abbre.QC:
                        // Assert
                        Assert.Equal(item == origine ? (float)p.Price * (1 + t.GST + t.PST) : (float)p.Price * (1 + t.GST)
                            , item != origine ? 105.0f : 115.0f, 2);
                        break;
                    case TaxesCanada.Abbre.SK:
                        // Assert
                        Assert.Equal(item == origine ? (float)p.Price * (1 + t.GST + t.PST) : (float)p.Price * (1 + t.GST)
                            , item != origine ? 105.0f : 111.0f, 2);
                        break;
                    case TaxesCanada.Abbre.YT:
                        // Assert
                        Assert.Equal(item == origine ? (float)p.Price * (1 + t.GST + t.PST) : (float)p.Price * (1 + t.GST)
                            , item != origine ? 105.0f : 105.0f, 2);
                        break;
                    case TaxesCanada.Abbre.Autre:
                        // Assert
                        Assert.Equal(item == origine ? (float)p.Price * (1 + t.GST + t.PST) : (float)p.Price * (1 + t.GST)
                            , item != origine ? 100.0f : 100.0f, 2);
                        break;
                    default:
                        break;
                }
            }
        }
        
    }
}
