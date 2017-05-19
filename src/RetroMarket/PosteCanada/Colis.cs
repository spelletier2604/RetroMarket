using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace RetroMarket.PosteCanada
{
    public class Colis
    { 
        public readonly string adresseOrigine; // Pour fin de démo, le code postal
        public readonly string adresseDestination; // Pour fin de démo, le code postal
        public ReadOnlyCollection<ArticlePanier> articles;
        public List<FraisDePort> tarifs; // Les tarifs pour les différents pourvoyeurs (ex. Poste Canada, Purolator)

        public Colis(string p_adresseOrigine, string p_adresseDestination, List<ArticlePanier> p_articles)
        {
            adresseOrigine = p_adresseOrigine;
            adresseDestination = p_adresseDestination;
            articles = p_articles.AsReadOnly();
            tarifs = new List<FraisDePort>();
        }

        public Colis()
        {
            adresseOrigine = "";
            adresseDestination = "";
            articles = new List<ArticlePanier>().AsReadOnly();
            tarifs = new List<FraisDePort>();
        }

        public int NbArticles
        {
            get { return articles.Count; }
        }

        public List<FraisDePort> Tarifs
        {
            get { return tarifs; }
            set { } 
        }
        public decimal PoidsTotal => articles.Sum(x => (decimal)(x?.Poids));

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Adresse d'origine du colis : ");
            sb.Append(adresseOrigine);
            sb.Append("\nAdresse de destination du colis : ");
            sb.Append(adresseDestination);
            sb.Append("\nNombre d'articles dans le colis : ");
            sb.Append(NbArticles);
            sb.Append("\nLa liste des tarifs : ");
            for (int i = 0; i < tarifs.Count; ++i)
            {
                sb.Append("\n");
                sb.Append(tarifs[i].Montant);
            }
            return sb.ToString();
        }

    }
}
