namespace ritaripeli
{
    internal class Ruoka : Tavara
    {
        public int Parannus { get; }

        public Ruoka(string nimi, int parannus) : base(nimi)
        {
            Parannus = parannus;
        }
    }
}
