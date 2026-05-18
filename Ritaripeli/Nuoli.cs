namespace ritaripeli
{
    internal class Nuoli : Tavara
    {
        public int Vahinko { get; private set; }

        public Nuoli(int vahinko)
        {
            Vahinko = vahinko;
        }
    }
}
