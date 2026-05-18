using System;
using System.Collections.Generic;

namespace Ritaripeli
{
    public class Reppu
    {
        private List<ITavara> tavarat = new List<ITavara>();

        public IReadOnlyList<ITavara> Tavarat => tavarat;

        public void Lisaa(ITavara tavara)
        {
            tavarat.Add(tavara);
        }

        public void Poista(ITavara tavara)
        {
            tavarat.Remove(tavara);
        }

        public void ListaaTavarat()
        {
            if (tavarat.Count == 0)
            {
                Console.WriteLine("Reppu on tyhjä.");
                return;
            }

            int i = 1;
            foreach (var t in tavarat)
            {
                Console.WriteLine($"{i}. {t.Nimi} ({t.Hinta} kr)");
                i++;
            }
        }
    }
}
