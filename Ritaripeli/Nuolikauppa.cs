using System.Collections.Generic;

namespace ritaripeli
{
    internal class Nuolikauppa : IKauppa
    {
        private List<TavaraJaHinta> myytavat = new List<TavaraJaHinta>()
        {
            new TavaraJaHinta(new Nuoli("Perusnouli", 1), 2),
            new TavaraJaHinta(new Nuoli("Perusnouli", 2), 4),
            new TavaraJaHinta(new Nuoli("Perusnuoli", 3), 6)
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
