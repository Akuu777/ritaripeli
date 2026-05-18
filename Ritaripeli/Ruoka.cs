namespace ritaripeli
{
    internal class Ruoka : Tavara
    {
        public int ParannusMaara { get; private set; }
        public string Nimi { get; private set; }

        public Ruoka(string nimi, int parannus)
        {
            Nimi = nimi;
            ParannusMaara = parannus;
        }
    }
}
