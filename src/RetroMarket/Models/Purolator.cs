using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RetroMarket.Models
{
    public class Purolator
    {
        public int PurolatorID { get; set; }

        [Required(ErrorMessage = "Veuillez indiquer la marge de poids.")]
        public int MargedePoid { get; set; }

        [Required(ErrorMessage = "Veuillez indiquer la modificateur")]
        public float Modificateur { get; set; }
    }
}
