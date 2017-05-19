using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetroMarket.Models.ViewModels
{
    public class ShipViewModel
    {
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public bool Valid { get; set; }
        // Prix SANS taxes SANS livraisons
        public float PriceRaw { get; set; }
        // Prix AVEC taxe SANS livraisons
        public float PriceTaxes { get; set; }
        // Prix de la livraisons
        public float PriceShip { get; set; }
        // Prix AVEC taxes AVEC livraisons
        public float PriceTotal { get; set; }
        public int PriceCents { get; set; }
        public string Shipper { get; set; }

    }
    public class ShipOptions
    {
        public int Id { get; set; }
        public string ShipName { get; set; }
    }
}
