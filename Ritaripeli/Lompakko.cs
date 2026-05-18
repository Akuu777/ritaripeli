using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ritaripeli
{
    /// <summary>
    /// Tämä luokka esittää ritarin varallisuutta.
    /// Se on erillinen jotta kauppa voi käsitellä
    /// ritarin rahoja helpommin.
    /// </summary>
    internal class Lompakko
    {
        public int Rahoja { get; private set; }
        public Lompakko(int aloitusRahoja)
        {
            Rahoja = aloitusRahoja;
        }
        public int OtaRahaa(int määrä)
        {
            if (Rahoja >= määrä)
            {
                Rahoja -= määrä;
                return määrä;
            }
            else
            {
                return 0;
            }
        }
        public void LisääRahaa(int määrä)
        {
            Rahoja += määrä;
        }

    }
}