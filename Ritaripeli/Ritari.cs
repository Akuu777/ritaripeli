namespace ritaripeli
{
    internal class Ritari
    {
        public int Osumapisteet { get; private set; }
        private Reppu reppu;
        public Lompakko Rahapussi { get; private set; }

        public Ritari(int aloitusOsumapisteet, int aloitusRahat)
        {
            Osumapisteet = aloitusOsumapisteet;
            Rahapussi = new Lompakko(aloitusRahat);
            reppu = new Reppu();
        }

        public void OtaVahinkoa(int määrä)
        {

        }
    }
}
