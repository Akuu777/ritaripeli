namespace ritaripeli
{
    internal class Susi : Hirviö
    {
        private Random rng = new Random();

        public Susi()
        {
            Nimi = "Susi";
            Osumapisteet = 5;
        }

        public override int AnnaVahinko()
        {
            return rng.Next(1, 3);
        }

        public override void OtaVahinkoa(int määrä)
        {
            Osumapisteet -= määrä;
        }
    }
}
