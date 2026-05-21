namespace ritaripeli
{
    internal class Peikko : Hirviö
    {
        private Random rng = new Random();

        public Peikko()
        {
            Nimi = "Peikko";
            Osumapisteet = 10;
            KultaPalkinto = 5;
        }

        public override int AnnaVahinko()
        {
            return rng.Next(2, 5);
        }

        public override void OtaVahinkoa(int määrä)
        {
            Osumapisteet -= määrä;
        }
    }
}
