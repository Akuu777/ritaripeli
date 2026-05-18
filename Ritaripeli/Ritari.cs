using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ritaripeli
{
    internal class Ritari
    {
        public int Osumapisteet { get; private set; }
        // TODO private Reppu reppu;
        public Lompakko Rahapussi { get; private set; }

        public Ritari(int aloitusOsumapisteet, int aloitusRahat)
        {
            Osumapisteet = aloitusOsumapisteet;
            Rahapussi = new Lompakko(aloitusRahat);
            // TODO luo tyhjä Reppu
        }

        public void OtaVahinkoa(int määrä)
        {

        }

    }
}