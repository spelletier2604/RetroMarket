using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace RetroMarket.Models
{
    public class TypeProduit
    {
        public int TypeProduitID { get; set; }

        [Required(ErrorMessage = "Entrez un type de produit")]
        public string Nom { get; set; }

        public int CategorieID { get; set; }
        public Categorie Categ { get; set; }
    }
}
