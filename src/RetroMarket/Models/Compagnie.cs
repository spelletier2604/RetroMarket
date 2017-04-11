using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace RetroMarket.Models
{
    /// <summary>
    /// Représente une compagnie produisant des consoles et/ou des jeux
    /// </summary>
    public class Compagnie
    {
        public int CompagnieID { get; set; }

        [Required(ErrorMessage = "Entrez le nom de la compagnie")]
        public string Nom { get; set; }
        [Required(ErrorMessage = "Entrez le pays de la companie")]
        public string Pays { get; set; }

        public List<TypeProduit> TypesProduit { get; set; }
    }
}
