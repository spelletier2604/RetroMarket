using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace RetroMarket.Models
{
    /// <summary>
    /// Représente l'adresse d'un client
    /// </summary>
    public class Adresse
    {
        public int AdresseID { get; set; }

        [Required(ErrorMessage = "Veuillez entrer le numéro civic")]
        public int NoCivic { get; set; }

        [Required(ErrorMessage = "Veuillez entrer le nom de la rue")]
        public string Rue { get; set; }

        [Required(ErrorMessage = "Veuillez entrer le nom de la ville")]
        public string Ville { get; set; }

        [Required(ErrorMessage = "Veuillez entrer le code postal")]
        [RegularExpression("[A-Z][0-9][A-Z] [0-9][A-Z][0-9]")]
        public string CodePostal { get; set; }

        [Required(ErrorMessage = "Veuillez entrez le nom de la province ou de l'état")]
        public string Province_Etat { get; set; }

        [Required(ErrorMessage = "Veuillez entrer votre numéro de téléphone")]
        public string NoTelephone { get; set; }
    }
}
