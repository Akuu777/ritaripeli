namespace ritaripeli
{
    internal class Nuoli : Tavara
    {
        public int Vahinko { get; }

        public Nuoli(string nimi, int dmg) : base(nimi)
        {
            Vahinko = dmg;
        }
    }
}
