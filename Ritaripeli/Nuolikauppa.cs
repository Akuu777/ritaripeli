namespace ritaripeli
{
    internal class Nuolikauppa : IKauppa
    {
        private List<TavaraJaHinta> myytavat = new List<TavaraJaHinta>()
        {
            new TavaraJaHinta(new Nuoli("Perusnuoli", 4), 2),
            new TavaraJaHinta(new Nuoli("Hienonuoli", 6), 4),
            new TavaraJaHinta(new Nuoli("Lohikäärmenuoli", 8), 6),
            new TavaraJaHinta(new Miekka("Teräsmiekka", 5), 5),
            new TavaraJaHinta(new Miekka("Kultamiekka", 7), 8)
        };

        public List<TavaraJaHinta> ListaaTavarat()
        {
            return myytavat;
        }

        public Tavara? OstaTavara(int valittuTavara, Lompakko rahapussi)
        {
            if (valittuTavara < 0 || valittuTavara >= myytavat.Count)
                return null;

            TavaraJaHinta tuote = myytavat[valittuTavara];

            if (rahapussi.Rahat >= tuote.Hinta)
            {
                rahapussi.VahennaRahaa(tuote.Hinta);
                return tuote.Esine;
            }

            return null;
        }
    }
}
