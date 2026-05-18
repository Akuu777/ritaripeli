using System.Collections.Generic;

namespace ritaripeli
{
    internal class Ravintola : IKauppa
    {
        private List<TavaraJaHinta> myytavat = new List<TavaraJaHinta>()
        {
            new TavaraJaHinta(new Ruoka("Pieni ateria", 2), 3),
            new TavaraJaHinta(new Ruoka("Keskikokoinen ateria", 4), 5),
            new TavaraJaHinta(new Ruoka("Iso ateria", 6), 8)
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

            int maksettu = rahapussi.OtaRahaa(tuote.Hinta);

            if (maksettu == 0)
                return null;

            return tuote.Esine;
        }
    }
}
