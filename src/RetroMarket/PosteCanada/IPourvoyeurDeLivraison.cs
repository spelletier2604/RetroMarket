namespace RetroMarket.PosteCanada
{
    public interface IPourvoyeurDeLivraison
    {
        string nomPourvoyeur { get; }
        void GetTarifs();
    }
}
