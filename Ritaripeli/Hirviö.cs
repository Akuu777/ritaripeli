using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ritaripeli
{
    internal abstract class Hirviö
    {
        public int KultaPalkinto { get; protected set; }
        public int Osumapisteet { get; set; }
        public string Nimi { get; set; }
        public abstract int AnnaVahinko();
        public abstract void OtaVahinkoa(int määrä);
    }
}