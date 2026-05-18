namespace ritaripeli
{
    internal class Ritari
    {
        public int Osumapisteet { get; private set; }
        public Lompakko Rahapussi { get; private set; }
        public Reppu Reppu { get; private set; }

        public Ritari(int aloitusOsumapisteet, int aloitusRahat)
        {
            Osumapisteet = aloitusOsumapisteet;
            Rahapussi = new Lompakko(aloitusRahat);
            Reppu = new Reppu();
        }

        public void OtaVahinkoa(int määrä)
        {
            Osumapisteet -= määrä;
            if (Osumapisteet < 0)
                Osumapisteet = 0;
        }
    }
}
