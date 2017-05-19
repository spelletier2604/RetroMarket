using System;

namespace RetroMarket.PosteCanada
{
    public class PourvoyeurDeLivraison : IPourvoyeurDeLivraison
    {
        
        public string nomPourvoyeur { get; set; }
        public Colis colis { get; set; }
        public virtual void GetTarifs() { }
        protected void AjouterFraisDePort(string p_codeService, string p_nom, decimal p_montant, DateTime p_dateLivraison)
        {
            colis.Tarifs.Add(new FraisDePort(nomPourvoyeur, p_codeService, p_nom, p_montant, p_dateLivraison));
        }
    }
}
