using System.ComponentModel.DataAnnotations;

namespace RetroMarket.Models {

    public class Product {
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Please enter a product name")]
        public string Name { get; set; }

        public bool Etat { get; set; } // Neuf ou usagé
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Please specify a category")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Please specify a weight")]
        public float Poids { get; set; }
    }
}
