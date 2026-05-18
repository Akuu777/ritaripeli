using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ritaripeli
{
    /// <summary>
    /// Tämä rajapinta esittää kaikenlaisia kauppoja.
    /// Kaupasta voi ostaa tavaroita rahaa vastaan
    /// Pelaaja voi listata kaupan tavarat ja niiden hinnat
    /// sekä ostaa tavaran.
    /// Jos pelaajalla ei ole tarpeeksi rahaa, tavaraa ei voi ostaa
    /// </summary>
    internal interface IKauppa
    {
        /// <summary>
        /// Palauttaa listan myynnissä olevista tavaroista ja niiden hinnoista
        /// </summary>
        /// <returns>Lista, jossa on jokainen myynnissä oleva tavara ja sen hinta</returns>
        public List<TavaraJaHinta> ListaaTavarat();

        /// <summary>
        /// Tätä funktiotat kutsutaan kun pelaaja haluaa ostaa tavaran
        /// myynnissä olevien tavaroiden listasta.
        /// </summary>
        /// <param name="valittuTavara">Minkä tavaran pelaaja haluaa ostaa. Jos arvo on negatiivinen tai suurempi kuin tavaroiden määrä, ostaminen ei onnistu</param>
        /// <param name="rahapussi">Pelaajan Lompakko. Jos lompakossa ei ole tarpeeksi rahaa valitun tavaran ostamiseen, ostaminen ei onnistu</param>
        /// <returns>Jos ostaminen onnistuu, palauttaa ostetun tavaran. Jos ostaminen epäonnistuu, palauttaa null</returns>
        public Tavara? OstaTavara(int valittuTavara, Lompakko rahapussi);


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