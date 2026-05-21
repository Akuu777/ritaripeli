namespace ritaripeli
{
    internal class Ravintola : IKauppa
    {
        public List<TavaraJaHinta> ListaaTavarat()
        {
            return new List<TavaraJaHinta>()
            {
                new TavaraJaHinta(new Ruoka("Pieni ateria", 2), 3),
                new TavaraJaHinta(new Ruoka("Iso ateria", 5), 6)
            };
        }

        public Tavara? OstaTavara(int valittuTavara, Lompakko rahapussi)
        {
            var tavarat = ListaaTavarat();

            if (valittuTavara < 0 || valittuTavara >= tavarat.Count)
                return null;

            TavaraJaHinta tuote = tavarat[valittuTavara];

            if (rahapussi.Rahat >= tuote.Hinta)
            {
                rahapussi.VahennaRahaa(tuote.Hinta);
                return tuote.Esine;
            }

            return null;
        }
    }
}