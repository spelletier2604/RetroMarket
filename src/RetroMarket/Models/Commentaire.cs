using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace RetroMarket.Models
{
    /// <summary>
    /// Représente un commentaire sur un produit par un acheteur
    /// </summary>
    public class Commentaire
    {
        public int CommentaireID { get; set; }

        [Required(ErrorMessage = "Veuillez indiquer un titre à votre commentaire")]
        public string Titre { get; set; }
        [Required(ErrorMessage = "Veillez noter le produit")]
        public int Note { get; set; }
        [Required(ErrorMessage = "Veillez entrer un commentaire")]
        public string Corps { get; set; }

        // Propriété à ajouter pour l'auteur.
    }
}
