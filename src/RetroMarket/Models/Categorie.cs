using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace RetroMarket.Models
{
    
    public class Categorie
    {
        public int CategorieID { get; set; }

        [Required(ErrorMessage = "Entrez une catégorie de produit")]
        public string Nom { get; set; }

        public List<TypeProduit> TypesProduit { get; set; }
    }
}
