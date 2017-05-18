using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetroMarket.Models.ViewModels
{
    public class ShipViewModel
    {
        public Order Order { get; set; }
        public bool Purolator { get; set; }
        public bool PosteCanada { get; set; }
        public bool Valid { get; set; }
        // Prix SANS taxes SANS livraisons
        public double PriceRaw { get; set; }
        // Prix AVEC taxe SANS livraisons
        public double PriceTaxes { get; set; }
        // Prix de la livraisons
        public double PriceShipPurolator { get; set; }
        // Prix de la livraisons
        public double PriceShipPosteCanada { get; set; }
        // Prix AVEC taxes AVEC livraisons
        public double PriceTotal { get; set; }

    }
}
