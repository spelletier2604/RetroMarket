using System;
using Xunit;
using RetroMarket.Models;
using System.Collections.Generic;

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

        public float CalculTransportPurolator(List<float> cart)
        {
            float result = 0.0f;
            float poids = 0.0f;
            float poidsArrondie = 0.0f;
            float prixPoids = 0.0f;

            foreach (float item in cart)
            {
                poids += item;
            }


            /*Devrait s'assurer qu'on a un chiffre arrondie à la valeur
             dizaine inférieur (Exemple 11 = 10)
             Exemple de ce que le code fait:
             56 / 10 = 5.6;
             5.6 - 0.5 = 5.1;
             Round(5.1) = 5;
             5 * 10 = 50;
             */
            float temp = poids / 10 - 0.4f;
            poidsArrondie = (float)Math.Round(temp) * 10;


            if (poidsArrondie > 151)
            {
                prixPoids = 1.16f;
            }
            else
            {
                //prixPoids = _context.Purolator.FirstOrDefault(x => x.MargedePoid == (int)poidsArrondie).Modificateur;
                switch (poidsArrondie)
                {
                    case 10:
                        prixPoids = 1.01f;
                        break;
                    case 20:
                        prixPoids = 1.02f;
                        break;
                    case 30:
                        prixPoids = 1.03f;
                        break;
                    case 40:
                        prixPoids = 1.04f;
                        break;
                    /* etc. */
                    default:
                        break;
                }
            }

            result = poids * prixPoids;
            return result;
        }

        [Fact]
        public void CalculSelonPuro()
        {
            //Arrange
            List<float> test1 = new List<float> { 5.0f, 5.0f };
            List<float> test2 = new List<float> { 10.0f, 10.0f };
            List<float> test3 = new List<float> { 15.0f, 16.0f };
            List<float> test4 = new List<float> { 20.0f, 22.0f };
            List<float> test5 = new List<float> { 150.0f, 20.0f };
            //Act
            float result1 = (float)Math.Round(CalculTransportPurolator(test1), 2);
            float result2 = (float)Math.Round(CalculTransportPurolator(test2), 2);
            float result3 = (float)Math.Round(CalculTransportPurolator(test3), 2);
            float result4 = (float)Math.Round(CalculTransportPurolator(test4), 2);
            float result5 = (float)Math.Round(CalculTransportPurolator(test5), 2);
            //Assert
            Assert.Equal(10.1f, result1);
            Assert.Equal(20.4f, result2);
            Assert.Equal(31.93f, result3);
            Assert.Equal(43.68f, result4);
            Assert.Equal(197.2f, result5);
        }

    }
}
