using System;
using System.Collections.Generic;

namespace ritaripeli
{
    internal interface IKauppa
    {
        List<TavaraJaHinta> ListaaTavarat();
        Tavara? OstaTavara(int valittuTavara, Lompakko rahapussi);
    }

    internal class TavaraJaHinta
    {
        public Tavara Esine { get; private set; }
        public int Hinta { get; private set; }

        public TavaraJaHinta(Tavara esine, int hinta)
        {
            Esine = esine;
            Hinta = hinta;
        }
    }
}
