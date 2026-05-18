namespace ritaripeli
{
    internal class Lohikaarme : Hirviö
    {
        private Random rng = new Random();

        public Lohikaarme()
        {
            Nimi = "Lohikäärme";
            Osumapisteet = 20;
        }

        public override int AnnaVahinko()
        {
            return rng.Next(4, 9);
        }

        public override void OtaVahinkoa(int määrä)
        {
            Osumapisteet -= määrä;
        }
    }
}
