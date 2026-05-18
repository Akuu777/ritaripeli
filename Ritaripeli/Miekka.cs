namespace ritaripeli
{
    internal class Miekka : Tavara
    {
        public int Vahinko { get; }

        public Miekka(string nimi, int dmg) : base(nimi)
        {
            Vahinko = dmg;
        }
    }
}
